using GooglePlayGames.BasicApi;
using GooglePlayGames;
using GameSparks.Api.Requests;
using UnityEngine;
using UnityEngine.UI;

public class AuthenticateManager : MonoSingleton<AuthenticateManager>
{
    public InputField displayNameInput, userNameInput, passwordInput;

    [SerializeField]
    private Text currUserDisplayName;
    [SerializeField]
    private Text authState;

    //// 계정이름과 비밀번호로 로그인
    //public void AuthorizePlayerBttn()
    //{
    //    new GameSparks.Api.Requests.AuthenticationRequest()
    //        .SetUserName(userNameInput.text)
    //        .SetPassword(passwordInput.text)
    //        .Send((response) =>
    //        {
    //            if (!response.HasErrors)
    //            {
    //                Debug.Log("로그인 성공...");
    //            }
    //            else
    //            {
    //                Debug.Log("로그인 실패..." + response.Errors.JSON.ToString());
    //            }
    //        });
    //}

    public void GoogleLoginBtnOnClick()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            // 서버 인증 코드가 생성되도록 요청하여
            // 연결된 게임스파크 서버 응용 프로그램과 토큰을 교환합니다.
            .RequestServerAuthCode(false)

            // 해당 유저의 이메일 주소를 요청합니다.
            // 이것이 추가되면 어플리케이션이 처음 실행될 때 동의창이 열립니다.
            .RequestEmail()
            .Build();

        // 초기화
        PlayGamesPlatform.InitializeInstance(config);

        // 활성화
        PlayGamesPlatform.Activate();

        Social.localUser.Authenticate(success =>
        {
            Debug.Log("IsSuccess: " + success);
            if(!success)
            {
                return;
            }

            // 로그인이 성공되었습니다.
            Debug.Log("GetServerAuthCode - " + PlayGamesPlatform.Instance.GetServerAuthCode());
            Debug.Log("GetIdToken - " + PlayGamesPlatform.Instance.GetIdToken());
            Debug.Log("Email - " + ((PlayGamesLocalUser)Social.localUser).Email);
            Debug.Log("GoogleId - " + Social.localUser.id);
            Debug.Log("UserName - " + Social.localUser.userName);
            Debug.Log("UserName - " + PlayGamesPlatform.Instance.GetUserDisplayName());

            GameSparkGoogleLogin();
        });
    }

    private void GameSparkGoogleLogin()
    {
        // 유저 이름
        string displayName = PlayGamesPlatform.Instance.GetUserDisplayName();

        // 인증 코드
        string authCode = PlayGamesPlatform.Instance.GetServerAuthCode();

        new GooglePlayConnectRequest()
            .SetRedirectUri("http://www.gamesparks.com/oauth2callback")
            .SetCode(authCode)
            .SetDisplayName(displayName)
            .Send((googlePlayAuthResponse) =>
            {
                // 로그인 성공
                if(!googlePlayAuthResponse.HasErrors)
                {
                    authState.text = "구글, 게임스파크 계정 연동 완료";
                    currUserDisplayName.text = googlePlayAuthResponse.DisplayName;

                    //SaveManager.Instance.CheckHasInGameData();
                    //PlayerDataManager.Instance.LoadPlayerData();
                }

                // 로그인 실패
                else
                {
                    authState.text = googlePlayAuthResponse.Errors.JSON.ToString();
                    currUserDisplayName.text = "실패";
                }
            });
    }
}
