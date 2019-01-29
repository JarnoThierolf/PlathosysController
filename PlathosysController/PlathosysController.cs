using PlathosysApiWrapper;
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace PlathosysController
{
    public class HookEventArgs : EventArgs
    {
        public bool HookOff { get; set; }
    }

    class PlathosysController
    {
        public event EventHandler<HookEventArgs> HookChanged;
        public event EventHandler<EventArgs> PlathosysDeviceReady;
        public event EventHandler<EventArgs> NoDeviceFound;

        Timer timerHook;
        private Timer _timerInitPlathosys;
        private NotifyIconContext _notifyIconContext;
        private bool _deviceWorking;
        private bool hookOff;

        public PlathosysController(NotifyIconContext notifyIconContext)
        {
            timerHook = new Timer(new TimerCallback(timerHook_Tick), null, Timeout.Infinite, Timeout.Infinite);
            _timerInitPlathosys = new Timer(new TimerCallback(TimerInitPlathosys_Tick), null, 10, 1000);
            _notifyIconContext = notifyIconContext;
            _deviceWorking = false;
            hookOff = false;
        }

        /// <summary>
        /// Open connection to Plathosys device
        /// </summary>
        private void OpenPlathosys()
        {
            // choose specific USB ID or 0 for first Device found
            int vendorID = 0;
            int productID = 0;
            // Variables to store found IDs
            int selectedVendorID;
            int selectedProductID;
            // Stringbuilder instances to store DeviceName and SerialNumber with max. 200 characters
            StringBuilder deviceName = new StringBuilder(200);
            StringBuilder serialNumber = new StringBuilder(200);

            try
            {
                if (Plathosys.Opendevice(vendorID, productID,
                    out selectedVendorID, out selectedProductID,
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
            byte info1, info2, info3, info4, info5, info6, info7, info8, info9, info10;
            byte info11, info12, info13, info14, info15, info16;

            try
            {
                if (Plathosys.ReadCurrentInfodB(out info1, out info2, out info3, out info4,
                    out info5, out info6, out info7, out info8, out info9, out info10,
                    out info11, out info12, out info13, out info14, out info15, out info16))
                    return true;
            }
            catch
            {
                Plathosys.Closedevice();
            }

            hookOff = false;
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

                // If initializing the Plathosys device to get correct hook status and turning speaker off is successful
                if (InitPlathosys() && Plathosys.SetByListening(false))
                {
                    // Stop this timmer
                    _timerInitPlathosys.Change(Timeout.Infinite, Timeout.Infinite);
                    // Start timer to monitor hook status
                    timerHook.Change(10, 100);
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
                if (tmpHookOff != hookOff)
                {
                    hookOff = tmpHookOff;
                    OnHookChanged(hookOff);
                }
            }
            else
            {
                // Close connecion to Plathsoys device and retry
                Plathosys.Closedevice();
                timerHook.Change(Timeout.Infinite, Timeout.Infinite);
                _timerInitPlathosys.Change(10, 1000);
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
        /// <param name="activate">1 for on and 2 for off</param>
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
            _deviceWorking = false;
            OnNoDeviceFound();
            _timerInitPlathosys.Change(10, 1000);
        }
    }
}