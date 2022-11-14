
# FileUploadDownload_API_Call_Using_DLL
This the DLL source code , which can be used to call file download /Upload APIs

Please find the DLL details below

File Download
--------------------------------------------
Namespace : FileUploadAndDownload

Class :RESTCallFileDownload

Functions :

  1 . FileDownloadRequest_GET (This method is specifically for GET APIs)
  
      Inputs :
      
             - string domain (eg : so***-av.***.sp***.com) 
             
             - string apiUrl (eg: https://so***-av.***.sp***.com/getFile/123)
             
             - string cookie (eg: key1=value1;key2=value2)
             
             - string headers (eg: key1=value1;key2=value2)
             
             - string outputFolder (eg : E:\SIKHA\Test)
             
  2 . FileDownloadRequest (This method is for both GET& POST types of APIs)
  
      Inputs :
      
             - string domain (eg : so***-av.***.sp***.com) 
             
             - string apiUrl (eg: https://so***-av.***.sp***.com/getFile/123)
             
             - string cookie (eg: key1=value1;key2=value2)
             
             - string headers (eg: key1=value1;key2=value2)
             
             - string method (eg : POST)
             
             - string inputData (eg:  {"fileid":"12345"} )
             
             - string outputFolder (eg : E:\SIKHA\Test)
             
  


File Upload
--------------------------------------------
Namespace : FileUploadAndDownload

Class : RESTCallFileUpload

Functions : 

  1 . FileUploadRequest
  
       Inputs :
       
            - string uri (eg :http://localhost:8080/upload)
            
            - string token (eg : Bearer shdgajsgdhgas)
            
            - string paramsJson (eg :  {"name":"BASHlog.txt","parent":"232"} )
    
