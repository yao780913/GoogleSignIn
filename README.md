# GoogleSignIn

### Web.Config 
#### 需另增加 connectionStrings.config
```
<connectionStrings>
  <add name="DbEntities" 
       connectionString="{connectionString}" 
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```
#### 需另增加 appSettings.config
```
<appSettings>
  <add key="webpages:Version" value="3.0.0.0" />
  <add key="webpages:Enabled" value="false" />
  <add key="ClientValidationEnabled" value="true" />
  <add key="UnobtrusiveJavaScriptEnabled" value="true" />
  <add key="GoogleApiKey" value="{your google api key}"/>
  <add key="GoogleClientId" value="{your google client id}"/>
</appSettings>
```
