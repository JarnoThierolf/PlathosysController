using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace PlathosysController
{
    class PlathosysController
    {
        public event EventHandler<HookEventArgs> HookChanged;
        public event EventHandler<EventArgs> PlathosysDeviceReady;
        public event EventHandler<EventArgs> NoDeviceFound;

        private Timer _timerHook;
        private Timer _timerInitPlathosys;
        private bool _deviceWorking;
        private bool _hookOff;

        public PlathosysController()
        {
            _timerHook = new Timer(new TimerCallback(timerHook_Tick), null, Timeout.Infinite, Timeout.Infinite);
            _timerInitPlathosys = new Timer(new TimerCallback(TimerInitPlathosys_Tick), null, 10, 1000);
            _deviceWorking = false;
            _hookOff = false;
        }

        /// <summary>
        /// Open connection to Plathosys device
        /// </summary>
        private void OpenPlathosys()
        {
            // choose specific USB ID or 0 for first Device found
            int vendorID = 0;
            int productID = 0;
            // Stringbuilder instances to store DeviceName and SerialNumber with max. 200 characters
            StringBuilder deviceName = new StringBuilder(200);
            StringBuilder serialNumber = new StringBuilder(200);

            try
            {
                if (Plathosys.Opendevice(vendorID, productID,
                    out int selectedVendorID, out int selectedProductID,
                    deviceName, serialNumber) == false)
                {
                    throw new Exception("No Plathosys device detected!");
                }
            }
            catch (DllNotFoundException ex)
            {
                _timerInitPlathosys.Change(Timeout.Infinite, Timeout.Infinite);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Initialize the Plathosys device to get correct hook status
        /// </summary>
        /// <returns>succesful?</returns>
        private bool InitPlathosys()
        {
            try
            {
                if (Plathosys.ReadCurrentInfodB(out byte info1, out byte info2, out byte info3, out byte info4,
                    out byte info5, out byte info6, out byte info7, out byte info8, out byte info9, out byte info10,
                    out byte info11, out byte info12, out byte info13, out byte info14, out byte info15, out byte info16))
                    return true;
            }
            catch
            {
                ReconnectDevice();
            }

            _hookOff = false;
            return false;
        }

        /// <summary>
        /// Read hook info
        /// </summary>
        /// <param name="hookOff"></param>
        /// <returns>succesful?</returns>
        private bool ReadHookPlathosys(out bool hookOff)
        {
            int hookAndPttInfo;

            try
            {
                // If reading the hook info succeeds
                if (Plathosys.ReadHookAndPTT(out hookAndPttInfo))
                {
                    hookOff = ((hookAndPttInfo & 1) == 1) ? true : false;
                    return true;
                }
            }
            catch
            {
                Plathosys.Closedevice();
            }

            hookOff = false;
            return false;
        }

        /// <summary>
        /// Opens connection to Plathosys device and
        /// initialize it to get correct hook status
        /// </summary>
        /// <param name="sender"></param>
        private void TimerInitPlathosys_Tick(object sender)
        {
            try
            {
                OpenPlathosys();

                // If initializing the Plathosys device to get correct hook status
                // and turning off all accessories is successful
                if (InitPlathosys() &&
                    Plathosys.SetHeadsetActive(false) &&
                    Plathosys.SetByListening(false) &&
                    Plathosys.SetHeadsetEar(2))
                {
                    // Stop this timmer
                    _timerInitPlathosys.Change(Timeout.Infinite, Timeout.Infinite);
                    // Start timer to monitor hook status
                    _timerHook.Change(10, 100);
                    _deviceWorking = true;
                    // Raise PlathosysDeviceRead Event
                    OnPlathosysDeviceReady();
                }
            }
            catch (Exception)
            {
                // Try again in one second
            }
        }

        /// <summary>
        /// Read hook state and raise HoockChanged event
        /// </summary>
        /// <param name="sender"></param>
        private void timerHook_Tick(object sender)
        {
            bool tmpHookOff;

            // If reading Hook Info succeeds
            if (ReadHookPlathosys(out tmpHookOff))
            {
                // Raise HookChanged event according to hookInfo if hook status changed
                if (tmpHookOff != _hookOff)
                {
                    _hookOff = tmpHookOff;
                    OnHookChanged(_hookOff);
                }
            }
            else
            {
                // Close connecion to Plathsoys device and retry
                ReconnectDevice();
            }
        }

        /// <summary>
        /// OnChangedHook Event
        /// </summary>
        /// <param name="hookOff"></param>
        protected virtual void OnHookChanged(bool hookOff)
        {
            // If there are subscribers to the event
            if (HookChanged != null)
                HookChanged(this, new HookEventArgs() { HookOff = hookOff });
        }

        /// <summary>
        /// OnPlathosysDeviceReady Event
        /// </summary>
        protected virtual void OnPlathosysDeviceReady()
        {
            // If there are subscribers to the event
            if (PlathosysDeviceReady != null)
                PlathosysDeviceReady(this, new EventArgs());
        }

        /// <summary>
        /// OnNoDeviceFound Event
        /// </summary>
        protected virtual void OnNoDeviceFound()
        {
            // If there are subscribers to the event
            if (NoDeviceFound != null)
                NoDeviceFound(this, new EventArgs());
        }

        /// <summary>
        /// Set speaker port to given state
        /// </summary>
        /// <param name="activate">true for on an false for off</param>
        public void SetSpeaker(bool activate)
        {
            if (_deviceWorking == false)
            {
                throw new Exception("No Plathosys device detected!");
            }

            if (Plathosys.SetByListening(activate) == false)
            {
                ReconnectDevice();
                throw new Exception("Setting speaker port failed! Please check if Plathosys device is attached and try again.");
            }
        }

        /// <summary>
        /// Set headset port to given state
        /// </summary>
        /// <param name="activate">true for on an false for off</param>
        public void SetHeadset(bool activate)
        {
            if (_deviceWorking == false)
            {
                throw new Exception("No Plathosys device detected!");
            }

            if ((Plathosys.SetHeadsetEar(2) &&
                Plathosys.SetHeadsetActive(activate) == false))
            {
                ReconnectDevice();
                throw new Exception("Setting headset port failed! Please check if Plathosys device is attached and try again.");
            }
        }

        /// <summary>
        /// Set training function to given state
        /// </summary>
        /// <param name="activate">true for on and false for off</param>
        public void SetTraining(bool activate)
        {
            if (_deviceWorking == false)
            {
                throw new Exception("No Plathosys device detected!");
            }

            if ((Plathosys.SetHeadsetActive(false) &&
                Plathosys.SetHeadsetEar((activate) ? 1 : 2)) == false)
            {
                ReconnectDevice();
                throw new Exception("Setting training function failed! Please check if Plathosys device is attached and try again.");
            }
        }

        /// <summary>
        /// Reset and try to reconnet to Plathosys device
        /// </summary>
        private void ReconnectDevice()
        {
            _timerHook.Change(Timeout.Infinite, Timeout.Infinite);
            _deviceWorking = false;
            OnNoDeviceFound();
            Plathosys.Closedevice();
            _timerInitPlathosys.Change(10, 1000);
        }
    }

    public class HookEventArgs : EventArgs
    {
        public bool HookOff { get; set; }
    }
}