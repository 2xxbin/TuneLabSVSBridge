using TuneLab.Extensions.Voices;

namespace $safeprojectname$ForTuneLab
{
    /// <summary>
    /// TuneLab 내부에서 사용하는 가수 클래스입니다.
    /// 렌더링을 해당 클래스에서 담당하게 됩니다.
    /// </summary>
    public class $safeprojectname$Singer
    {
        /// <summary>
        /// TuneLab이 인식하는 가수의 아이디입니다.
        /// 각 아이디는 고유해야 합니다.
        /// </summary>
        public string ID;

        /// <summary>
        /// 가수의 경로입니다.
        /// </summary>
        public string SingerPath;

        /// <summary>
        /// 모델의 이름 등 설명이 담긴 클래스 입니다.
        /// TuneLab 내부 규격에 맞춰있습니다.
        /// </summary>
        public VoiceSourceInfo Info;

        public $safeprojectname$Singer(string path, string name, string desciption)
        {
            this.SingerPath = path;
            this.ID = "$safeprojectname$_" + name;

            VoiceSourceInfo info = default(VoiceSourceInfo);
            info.Name = name;
            info.Description = desciption;
            this.Info = info;
        }
    }
}
