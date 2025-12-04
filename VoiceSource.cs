using TuneLab.Base.Properties;
using TuneLab.Base.Structures;
using TuneLab.Extensions.Voices;

namespace $safeprojectname$ForTuneLab
{
    /// <summary>
    /// 가수 트랙에서 사용되는 보이스 정보입니다.
    /// 오토메이션, 기본 가사, 파트 세그먼트 방법 등을 정의합니다.
    /// </summary>
    public class $safeprojectname$VoiceSource : IVoiceSource
    {
        /// <summary>
        /// 로드된 가수입니다.
        /// </summary>
        private $safeprojectname$Singer Singer;

        public $safeprojectname$VoiceSource($safeprojectname$Singer singer) => this.Singer = singer;

        /// <summary>
        /// 트랙 창에서 표시되는 가수 이름입니다.
        /// </summary>
        public string Name { get => this.Singer.Info.Name; }

        /// <summary>
        /// 노트 생성 시, 기본적으로 적히는 가사 입니다.
        /// </summary>
        public string DefaultLyric { get => "a"; }

        /// <summary>
        /// 파트 전체에 적용되는 파라미터 입니다.
        /// Key는 ID이며, 이름 표시 및 추후 파라미터 로드 시 사용되기 때문에 고유해야 합니다.
        /// Value는 설정 종류이며, 상황에 맞게 다양한 설정을 사용 가능합니다.
        /// 사용 가능한 설정 종류는 아래 링크를 참고해주세요. : https://github.com/LiuYunPlayer/TuneLab/tree/master/TuneLab.Base/Properties
        /// </summary>
        public IReadOnlyOrderedMap<string, IPropertyConfig> PartProperties { get; }
            = new OrderedMap<string, IPropertyConfig>
            {
                { "Part Prop Test", new NumberConfig(0, -1, 1) }
            };

        /// <summary>
        /// 각 노트에 적용되는 파라미터 입니다.
        /// Key는 ID이며, 이름 표시 및 추후 파라미터 로드 시 사용되기 때문에 고유해야 합니다.
        /// Value는 설정 종류이며, 상황에 맞게 다양한 설정을 사용 가능합니다.
        /// 사용 가능한 설정 종류는 아래 링크를 참고해주세요. : https://github.com/LiuYunPlayer/TuneLab/tree/master/TuneLab.Base/Properties
        /// </summary>
        public IReadOnlyOrderedMap<string, IPropertyConfig> NoteProperties { get; }
            = new OrderedMap<string, IPropertyConfig>
            {
                { "Note Prop Test", new NumberConfig(0, -1, 1) }
            };

        /// <summary>
        /// 오토메이션 설정입니다.
        /// Key는 ID이며, 이름 표시 및 추후 파라미터 로드 시 사용되기 때문에 고유해야 합니다.
        /// Value는 오토메이션 클래스이며, 오토메이션에 필요한 값을 설정합니다.
        /// </summary>
        public IReadOnlyOrderedMap<string, AutomationConfig> AutomationConfigs { get; }
            = new OrderedMap<string, AutomationConfig>
            {
                { "Automation Test", new AutomationConfig("Test", 50.0, 0.0, 100.0, "#FFFFFF") }
            };

        /// <summary>
        /// TuneLab에서 파트 세그먼팅을 처리하는 방법을 정의합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="segment"></param>
        /// <returns></returns>
        public IReadOnlyList<SynthesisSegment<T>> Segment<T>(SynthesisSegment<T> segment) where T : ISynthesisNote
            => IVoiceSourceExtension.SimpleSegment<T>(
                this,
                segment,
                0.0,
                double.MaxValue
            );

        public ISynthesisTask CreateSynthesisTask(ISynthesisData data)
            => new $safeprojectname$SynthesisTask(data, this.Singer);
    }
}
