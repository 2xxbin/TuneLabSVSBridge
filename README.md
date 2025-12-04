# TuneLabSVSBridge

SVS용 확장 프로그램 기반 에디터인 [TuneLab](https://github.com/LiuYunPlayer/TuneLab)의 엔진 확장을 제작하기 위한 Visual Studio 템플릿 입니다.

TuneLab 공부 용이나, 확장 프로그램 제작 용으로 사용할 수 있습니다.

각 함수의 사용법 등은 TuneLab의 공식 코드들을 참고해주세요.

# 설치 방법

1. [Release 페이지](https://github.com/2xxbin/TuneLabSVSBridge/releases) 에서 버전을 다운받거나, 혹은 `Code -> Download ZIP` 기능을 사용하여 `zip` 파일을 다운받아 주세요.
2. `Visual Studio` 커스텀 프로젝트 템플릿 폴더에 ZIP 파일을 추가해주세요. (`%USERPROFILE%\Documents\Visual Studio <Version>\Templates\ProjectTemplates`)

# 사용 방법

1. `Visual Studio`를 열어, 프로젝트 생성을 눌러주세요.
2. `TuneLabForEngine` 템플릿을 선택합니다.
3. 프로젝트 이름을 구현할 엔진 이름으로 입력 후, 만들기를 눌러 프로젝트를 생성합니다.
4. 프로젝트가 생성되면 참조 관리자를 엽니다.
5. `찾아보기(B)...`을 누른 뒤, `TuneLab` 설치 폴더로 들어가 아래 두 dll을 참조로 추가시킵니다.
  - `TuneLab.Base.dll`
  - `TuneLab.Extension.Voices.dll`
6. 확인을 눌러 종료 후, 주석에 맞춰 개발합니다.

