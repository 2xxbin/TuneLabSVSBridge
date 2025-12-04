using TuneLab.Base.Structures;
using TuneLab.Extensions.Voices;

namespace $safeprojectname$ForTuneLab
{
    /// <summary>
    /// TuneLab 브릿지의 진입점입니다.
    /// TuneLab이 실행 되자마자 로드 후 Init()가 실행됩니다.
    /// </summary>
    [VoiceEngine("$safeprojectname$")]
    public class $safeprojectname$Engine : IVoiceEngine
    {
        public $safeprojectname$Engine() { }

        /// <summary>
        /// 내부적으로 사용하는 가수 리스트 입니다.
        /// </summary>
        private $safeprojectname$Singer[] Singers = Array.Empty<$safeprojectname$Singer>();

        /// <summary>
        /// 확장 프로그램의 설치 경로입니다.
        /// </summary>
        private string ExtenstionPath = "";

        /// <summary>
        /// TuneLab에서 인식하는 가수 목록입니다.
        /// 해당 리스트를 기반으로, TuneLab에서는 가수를 인식합니다.
        /// </summary>
        public IReadOnlyOrderedMap<string, VoiceSourceInfo> VoiceInfos
        {
            get =>
                Singers.Aggregate(
                    new OrderedMap<string, VoiceSourceInfo>(),
                    (map, s) => { map.Add(s.ID, s.Info); return map; }
                );
        }

        /// <summary>
        /// TuneLab 실행시 실행되는 코드입니다.
        /// 엔진의 초기화 및 가수 로드 등을 담당합니다.
        /// </summary>
        /// <param name="extenstionPath">브릿지 프로그램의 설치 경로입니다.</param>
        /// <param name="error">해당 문자열이 비어있지 않을 경우, TuneLab은 프로그램에 문제가 생겼다 파악하여 오류를 발생 시킵니다.</param>
        /// <returns>
        ///     반환 값이 참일 경우, TuneLab이 초기화를 성공했다 판단합니다.
        ///     반대로 반환 값이 거짓일 경우, TuneLab이 정상적인 초기화를 실패했다 판단합니다.
        /// </returns>
        public bool Init(string extenstionPath, out string error)
        {
            this.ExtenstionPath = extenstionPath;
            error = "";

            try
            {
                // 해당 부분에 초기화 코드를 작성해주세요.

                return true;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// TuneLab에서 트랙을 생성한 뒤, 가수를 로드 했을 때 실행되는 함수 입니다.
        /// </summary>
        /// <param name="ID">가수의 고유 ID 입니다.</param>
        /// <returns>가수 정보가 담긴 IVoiceSource 구현체를 반환합니다.</returns>
        public IVoiceSource CreateVoiceSource(string ID)
            => new $safeprojectname$VoiceSource(
                Singers.FirstOrDefault(s => s.ID == ID) ??
                throw new Exception($"Singer not found: {ID}")
            );

        /// <summary>
        /// TuneLab 프로그램 종료시 실행되는 clean-up 함수입니다.
        /// 정상적인 초기화가 되어야 하는 프로그램에서 사용됩니다.
        /// </summary>
        public void Destroy() { }
    }
}
