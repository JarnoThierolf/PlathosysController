using System.Runtime.InteropServices;
using System.Text;

namespace PlathosysController
{
    class Plathosys
    {
        // ApiVersionNumber
        // static PLATHOSYSAPIDLL_API unsigned int PlathosysFn::ApiVersionNumber();		//Not with PID 0x0003,0x0004 devices;
        [DllImport("PlathosysApi.dll", EntryPoint = "?ApiVersionNumber@PlathosysFn@PlathosysApiFuncs@@SAIXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ApiVersionNumber();

        // Opendevice
        // static PLATHOSYSAPIDLL_API int PlathosysFn::Opendevice(unsigned int VendorID,unsigned int ProductID,unsigned int *GotVendorID,unsigned int *GotProductID, char *GotProductName, char *SerialNumber);
        [DllImport("PlathosysApi.dll", CharSet = CharSet.Ansi, EntryPoint = "?Opendevice@PlathosysFn@PlathosysApiFuncs@@SAHIIPAI0PAD1@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Opendevice(
            int vendorID,
            int productID,
            out int gotVendorID,
            out int gotProductID,
            StringBuilder gotProductName,
            StringBuilder gotSerialNumber);

        // Closedevice
        // static PLATHOSYSAPIDLL_API int PlathosysFn::Closedevice();
        [DllImport("PlathosysApi.dll", EntryPoint = "?Closedevice@PlathosysFn@PlathosysApiFuncs@@SAHXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool Closedevice();

        // IsDeviceOpen
        // static PLATHOSYSAPIDLL_API int PlathosysFn::IsDeviceOpen();
        [DllImport("PlathosysApi.dll", EntryPoint = "?IsDeviceOpen@PlathosysFn@PlathosysApiFuncs@@SAHXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool IsDeviceOpen();

        // SetHandsetVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHandsetVolume(unsigned int Volume);			//Do not use in new software client. (Use SetHandsetVolume() )
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetHandsetVolume@PlathosysFn@PlathosysApiFuncs@@SAHI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHandsetVolume(int volume);

        // SetHeadsetVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHeadsetVolume(unsigned int Volume);			//Do not use in new software client. (Use SetHeadsetdBVolume() )
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetHeadsetVolume@PlathosysFn@PlathosysApiFuncs@@SAHI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHeadsetVolume(int volume);

        // SetIntSpeakerVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetIntSpeakerVolume(unsigned int Volume);		//Do not use in new software client. (Use SetIntSpeakerdBVolume() )
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetIntSpeakerVolume@PlathosysFn@PlathosysApiFuncs@@SAHI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetIntSpeakerVolume(int volume);

        // SetIntSpeakerMute
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetIntSpeakerMute(bool State);
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetIntSpeakerMute@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetIntSpeakerMute(bool state);

        // SetHandsetMicVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHandsetMicVolume(unsigned int Volume);		//Do not use in new software client. (Use SetHandsetdBMicVolume() )
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetIntSpeakerMute@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHandsetMicVolume(int volume);

        // SetHeadsetMicVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHeadsetMicVolume(unsigned int Volume);		//Do not use in new software client. (Use SetHeadsetdBMicVolume() )
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetIntSpeakerMute@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHeadsetMicVolume(int volume);

        // SetExtMicVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetExtMicVolume(unsigned int Volume);			//Do not use in new software client. (Use SetExtMicdBVolume() )
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetExtMicVolume@PlathosysFn@PlathosysApiFuncs@@SAHI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetExtMicVolume(int volume);

        // SetIntSpeakerdBVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetIntSpeakerdBVolume(int dBVolume);					//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetIntSpeakerdBVolume@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetIntSpeakerdBVolume(int dBVolume);

        // SetIntAlarmSpeakerdBVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetIntAlarmSpeakerdBVolume(int dBVolume);				//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetIntAlarmSpeakerdBVolume@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetIntAlarmSpeakerdBVolume(int dBVolume);

        // SetIntAlarmSpeakerVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetIntAlarmSpeakerVolume(unsigned int Volume);			//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetIntAlarmSpeakerVolume@PlathosysFn@PlathosysApiFuncs@@SAHI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetIntAlarmSpeakerVolume(int volume);

        // ReadCurrentInfo
        // static PLATHOSYSAPIDLL_API int PlathosysFn::ReadCurrentInfo(unsigned char *Info1,unsigned char *Info2,unsigned char *Info3,unsigned char *Info4,unsigned char *Info5,unsigned char *Info6,
        // unsigned char* Info7, unsigned char* Info8, unsigned char* Info9, unsigned char* Info10); //Do not use in new software client. (Use ReadCurrentInfodB() )
        [DllImport("PlathosysApi.dll", EntryPoint = "?ReadCurrentInfo@PlathosysFn@PlathosysApiFuncs@@SAHPAE000000000@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ReadCurrentInfo(
            out byte info1, out byte info2, out byte info3, out byte info4, out byte info5,
            out byte info6, out byte info7, out byte info8, out byte info9, out byte info10);

        // ReadHookAndPTT
        // static PLATHOSYSAPIDLL_API int PlathosysFn::ReadHookAndPTT(unsigned int *HookPttInfo);
        [DllImport("PlathosysApi.dll", EntryPoint = "?ReadHookAndPTT@PlathosysFn@PlathosysApiFuncs@@SAHPAI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ReadHookAndPTT(out int hookAndPttInfo);

        // SetSideTone
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetSideTone(int OnOff);
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetSideTone@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetSideTone(bool onOff);

        // SetMicMute
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetMicMute(int OnOff);
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetMicMute@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetMicMute(bool onOff);

        // SetSpeakerOutMute
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetSpeakerOutMute(int OnOff);
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetSpeakerOutMute@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetSpeakerOutMute(bool onOff);

        // SetWideBand
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetWideBand(int OnOff);							//Only with PID 0x0001,0x0002 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetWideBand@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetWideBand(bool onOff);

        // SetEchoCanceller
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetEchoCanseller(int OnOff);					//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetEchoCanseller@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetEchoCanceller(bool onOff);

        // SetExtMic
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetExtMic(bool State);							//Only with PID 0x0001,0x0002 devices 
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetExtMic@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetExtMic(bool state);

        // SetConference
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetConference(bool State);						//Only with PID 0x0001,0x0002 devices 
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetConference@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetConference(bool state);

        // SetHeadsetActive
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHeadsetActive(bool State);					//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetHeadsetActive@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHeadsetActive(bool state);

        // SetWirelessHeadsetRinging
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetWirelessHeadsetRinging(bool State);			//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetWirelessHeadsetRinging@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetWirelessHeadsetRinging(bool state);

        // SetWirelessCall
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetWirelessCall(bool State);					//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetWirelessCall@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetWirelessCall(bool state);

        // SetPttFunctions
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetPttFunctions(unsigned int InVal);			//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetPttFunctions@PlathosysFn@PlathosysApiFuncs@@SAHI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetPttFunctions(int intVal);

        // SetHeadsetEar
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHeadsetEar(int OnOffRelease);				//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetHeadsetEar@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHeadsetEar(int onOffRelease);

        // SetExtmicLed
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetExtmicLed(bool State);						//Only with PID 0x0001,0x0002 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetExtmicLed@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetExtmicLed(bool state);

        // SetByListening
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetByListening(bool State);
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetByListening@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetByListening(bool state);

        // SetCodecType
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetCodecType(int CodecType);					//Only with PID 0x0001,0x0002 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetCodecType@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetCodecType(int codecType);

        // SetSerialNumber
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetSerialNumber(unsigned long Serno);			//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetSerialNumber@PlathosysFn@PlathosysApiFuncs@@SAHK@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetSerialNumber(int serialNo);

        // InitHookAndPTTState (Only for PID 3 + 4)
        // static PLATHOSYSAPIDLL_API int PlathosysFn::InitHookAndPTTState();
        [DllImport("PlathosysApi.dll", EntryPoint = "?InitHookAndPTTState@PlathosysFn@PlathosysApiFuncs@@SAHXZ", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool InitHookAndPTTState();

        // MuteSpkCt140
        // static PLATHOSYSAPIDLL_API int PlathosysFn::MuteSpkCt140(bool State);						//Only PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?MuteSpkCt140@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MuteSpkCt140(bool state);

        // MuteMicCt140
        // static PLATHOSYSAPIDLL_API int PlathosysFn::MuteMicCt140(bool State);						//Only PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?MuteMicCt140@PlathosysFn@PlathosysApiFuncs@@SAH_N@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool MuteMicCt140(bool state);

        // SetHeadsetdBVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHeadsetdBVolume(int dBVolume);						//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetHeadsetdBVolume@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHeadsetdBVolume(int dBVolume);

        // SetHeadsetMicdBVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetHeadsetMicdBVolume(int dBVolume);					//Not with PID 0x0003,0x0004 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetHeadsetMicdBVolume@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetHeadsetMicdBVolume(int dBVolume);

        // SetExtMicdBVolume
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetExtMicdBVolume(int dBVolume);						//Only with PID 0x0001,0x0002 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetExtMicdBVolume@PlathosysFn@PlathosysApiFuncs@@SAHH@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetExtMicdBVolume(int dBVolume);

        // SetLyncFeature
        // static PLATHOSYSAPIDLL_API int PlathosysFn::SetLyncFeature(unsigned int Feature );					//Only with PID 0x0005,0x0006 devices
        [DllImport("PlathosysApi.dll", EntryPoint = "?SetLyncFeature@PlathosysFn@PlathosysApiFuncs@@SAHI@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetLyncFeature(bool onOff);

        // ReadCurrentInfodB
        // static PLATHOSYSAPIDLL_API int PlathosysFn::ReadCurrentInfodB(unsigned char *Info1,unsigned char *Info2,unsigned char *Info3,unsigned char *Info4,unsigned char *Info5,unsigned char *Info6,
        //                                                                    unsigned char* Info7, unsigned char* Info8, unsigned char* Info9, unsigned char* Info10,
        //                                                                    char* Info11,char* Info12,char* Info13, char* Info14, char* Info15, unsigned char* Info16);
        [DllImport("PlathosysApi.dll", EntryPoint = "?ReadCurrentInfodB@PlathosysFn@PlathosysApiFuncs@@SAHPAE000000000PAD11110@Z", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool ReadCurrentInfodB(
            out byte info1, out byte info2, out byte info3, out byte info4, out byte info5, out byte info6,
            out byte info7, out byte info8, out byte info9, out byte info10, out byte info11, out byte info12,
            out byte info13, out byte info14, out byte info15, out byte info16);
    }
}