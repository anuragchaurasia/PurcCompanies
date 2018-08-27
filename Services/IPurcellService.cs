using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using EntityLayer;
using EntityLayer.Response;

namespace PurcellComplianceServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPurcellService" in both code and config file together.
    [ServiceContract]
    public interface IPurcellService
    {

        [OperationContract]
        [WebInvoke(Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Bare,
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "/Login")]
        UserLoginResponse Login(UserLoginRequest userRequest);

        [OperationContract]
        [WebInvoke(Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Bare,
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "/Logout")]
        UserLogoutResponse UserLogout(UserLogoutRequest userRequest);

        [OperationContract]
        [WebInvoke(Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Bare,
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "/UpdateProfile")]
        UpdateUserResponse UpdateProfile(UpdateUserRequest userRequest);

        [OperationContract]
        [WebInvoke(Method = "POST",
                 BodyStyle = WebMessageBodyStyle.Bare,
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/UpdateDeviceToken")]
        UpdateDeviceTokenResponse UpdatePushToken(UpdateDeviceTokenRequest userRequest);

        [OperationContract]
        [WebInvoke(Method = "GET",
                 BodyStyle = WebMessageBodyStyle.Bare,
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/GetDocs/{UserID}")]
        GetUserDocResponse GetUserDocs(string UserID);

        [OperationContract]
        [WebInvoke(Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Bare,
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "/SendDoc")]
        DocumentUploadResponse SendDocument(DocumentUploadRequest docUploadRequest);

        [OperationContract]
        [WebInvoke(Method = "POST",
                  BodyStyle = WebMessageBodyStyle.Bare,
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "/SendChangeRequest")]
        DocumentUploadResponse SendChangeRequest(DocumentUploadRequest docUploadRequest);

        [OperationContract]
        [WebInvoke(Method = "GET",
                 BodyStyle = WebMessageBodyStyle.Bare,
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/GetHashString/{inputString}")]
        string GetHashString(string inputString);


        [OperationContract]
        [WebInvoke(Method = "GET",
                 BodyStyle = WebMessageBodyStyle.Bare,
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/GetMobileLoginText/")]
        string[] GetMobileLoginText();


        [OperationContract]
        [WebInvoke(Method = "POST",
                 BodyStyle = WebMessageBodyStyle.Bare,
                 RequestFormat = WebMessageFormat.Json,
                 ResponseFormat = WebMessageFormat.Json,
                 UriTemplate = "/GetDocumentList")]
        GetUserDocResponse GetDocumentList(UploadUserRequest docRequest);
    }
}
