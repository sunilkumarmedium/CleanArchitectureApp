
/*
Table structure for table 'public.EmailTemplates'
*/

CREATE TABLE IF NOT EXISTS EmailTemplates (EmailTemplateId UUID NOT NULL,EmailTemplateInd BIGSERIAL NOT NULL,EmailTemplateName VARCHAR(200) ,EmailLabel VARCHAR(50) ,EmailSubject VARCHAR(500) ,EmailSenderEmail VARCHAR(50) ,EmailContent TEXT,EmailSignature VARCHAR(500) ,IsMasterTemplate BOOLEAN,EmailIsActive BOOLEAN,CreatedDate TIMESTAMP(3),UpdatedDate TIMESTAMP(3),CreatedBy UUID,UpdatedBy UUID);
DROP INDEX IF EXISTS "PK_EmailTemplates";
ALTER TABLE EmailTemplates ADD CONSTRAINT "PK_EmailTemplates" PRIMARY KEY (EmailTemplateId);

/*
Dumping data for table 'public.EmailTemplates'
*/

INSERT INTO EmailTemplates (EmailTemplateId,EmailTemplateInd,EmailTemplateName,EmailLabel,EmailSubject,EmailSenderEmail,EmailContent,EmailSignature,IsMasterTemplate,EmailIsActive,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy) VALUES ('18CB6A7134F54BED8D19346F5B8C019D', 1, 'ForgotPasswordNotification', 'Forgot Password Notification', 'Reset Password', 'info@gmail.com', 'Dear [Username], Your temporary password is [password]', '', '1', '1', '2020-11-21 14:42:23.097000', '2020-11-21 14:42:23.097000', '9FFA5061F38BA621E0EE3793D7EAF67B', '9FFA5061F38BA621E0EE3793D7EAF67B');


/*
Table structure for table 'public.EmailRecipients'
*/

CREATE TABLE IF NOT EXISTS EmailRecipients (EmailRecipientId UUID NOT NULL,EmailTemplateID UUID,RecipientUserID UUID,RecipientEmail VARCHAR(200) ,EmailLabel VARCHAR(50) ,EmailSubject VARCHAR(500) ,EmailSenderEmail VARCHAR(50) ,EmailContent TEXT,EmailSignature VARCHAR(500) ,IsPending BOOLEAN,ToBeProcessedOn TIMESTAMP(3),EmailSentOn TIMESTAMP(3),CreatedDate TIMESTAMP(3),UpdatedDate TIMESTAMP(3),CreatedBy UUID);
DROP INDEX IF EXISTS "PK_EmailRecipients";
ALTER TABLE EmailRecipients ADD CONSTRAINT "PK_EmailRecipients" PRIMARY KEY (EmailRecipientId);


/*
Table structure for table 'public.LoginLogTypes'
*/

CREATE TABLE IF NOT EXISTS LoginLogTypes (LoginLogTypeId UUID NOT NULL,LoginLogTypeName VARCHAR(50) );
DROP INDEX IF EXISTS "PK_LoginLogTypes";
ALTER TABLE LoginLogTypes ADD CONSTRAINT "PK_LoginLogTypes" PRIMARY KEY (LoginLogTypeId);

/*
Dumping data for table 'public.LoginLogTypes'
*/

INSERT INTO LoginLogTypes (LoginLogTypeId,LoginLogTypeName) VALUES ('1841087AC0774F8684625914279BBB83', 'Success');
INSERT INTO LoginLogTypes (LoginLogTypeId,LoginLogTypeName) VALUES ('5077898B82E148CB83B4933AA473BFAC', 'SSOSuccess');
INSERT INTO LoginLogTypes (LoginLogTypeId,LoginLogTypeName) VALUES ('35E328E5405C412BBA5CD329157236C2', 'IncorrectUserNameOrPassword');
INSERT INTO LoginLogTypes (LoginLogTypeId,LoginLogTypeName) VALUES ('F177AB9D380841C98256D97ECF9B6107', 'UserInActive');


/*
Table structure for table 'public.LoginLogs'
*/


CREATE TABLE IF NOT EXISTS LoginLogs (LoginLogId UUID NOT NULL,LoginLogInd BIGSERIAL NOT NULL,LoginDate TIMESTAMP(3),LoginUserIP VARCHAR(50) ,LoginSuccess BOOLEAN,LoginLogTypeId UUID,UserIdentifier VARCHAR(50) );
ALTER SEQUENCE LoginLogs_LoginLogInd_seq RESTART WITH 1 INCREMENT BY 1;
DROP INDEX IF EXISTS "PK_LoginLogs";
ALTER TABLE LoginLogs ADD CONSTRAINT "PK_LoginLogs" PRIMARY KEY (LoginLogId);

/*
Table structure for table 'public.UserStatuses'
*/

CREATE TABLE IF NOT EXISTS UserStatuses (UserStatusId SERIAL NOT NULL,StatusDescription VARCHAR(50) ,StatusValue VARCHAR(50)  NOT NULL);
ALTER SEQUENCE UserStatuses_UserStatusId_seq RESTART WITH 3 INCREMENT BY 1;
DROP INDEX IF EXISTS "PK_UserStatuses";
ALTER TABLE UserStatuses ADD CONSTRAINT "PK_UserStatuses" PRIMARY KEY (UserStatusId);

/*
Dumping data for table 'public.UserStatuses'
*/

INSERT INTO UserStatuses (UserStatusId,StatusDescription,StatusValue) VALUES (1, 'Active', 'Active');
INSERT INTO UserStatuses (UserStatusId,StatusDescription,StatusValue) VALUES (2, 'InActive', 'InActive');


/*
Table structure for table 'public.Users'
*/

CREATE TABLE IF NOT EXISTS Users (UserId UUID NOT NULL,UserName VARCHAR(50)  NOT NULL,FirstName VARCHAR(50)  NOT NULL,LastName VARCHAR(50) ,UserEmail VARCHAR(50)  NOT NULL,PasswordHash TEXT NOT NULL,PasswordSalt TEXT NOT NULL,UserStatusId INTEGER NOT NULL,CreatedDate TIMESTAMP(3) NOT NULL,UpdatedDate TIMESTAMP(3),CreatedBy UUID NOT NULL,UpdatedBy UUID);
DROP INDEX IF EXISTS "PK_Users";
ALTER TABLE Users ADD CONSTRAINT "PK_Users" PRIMARY KEY (UserId);

/*
Dumping data for table 'public.Users'
*/

INSERT INTO Users (UserId,UserName,FirstName,LastName,UserEmail,PasswordHash,PasswordSalt,UserStatusId,CreatedDate,UpdatedDate,CreatedBy,UpdatedBy) VALUES ('9FFA5061F38BA621E0EE3793D7EAF67B', 'system', 'System', 'Admin', 'systemadmin@gmail.com', 'VKM8pU0kY4yi+pWhfSP91E/gNKM1Kg3A7w3JI9CigiXoCpWJWQjFt2IIoxtkR88mljbD/BcY7Lb0+L6IVkmfuw==', 'jHRSqxS9/D3wZFq/ikOZy4RXOujJ18ybBq3HU1yzQdIa3nus5XpY84Xu2xrN+TGkOb74S6ZTl4gKgPrkmwCcJ3QU6jMiVIlmTDeFdwTLLnTaaqZkv/18du6uD9uGyvKvD3IeV2aQAMKCqB0yZIwfeI6F1TY2py61iAB5kugPs5o=', 1, '2020-11-14 23:16:01.333000', NULL, '9FFA5061F38BA621E0EE3793D7EAF67B', '00000000000000000000000000000000');


/*
Table structure for table 'public.UserTokens'
*/

CREATE TABLE IF NOT EXISTS UserTokens (UserTokenId UUID NOT NULL,UserId UUID,Token TEXT NOT NULL,JwtToken TEXT NOT NULL,ExpireDate TIMESTAMP(3) NOT NULL,ReplacedByToken TEXT,CreatedDate TIMESTAMP(3) NOT NULL,RevokedDate TIMESTAMP(3),CreatedByIp VARCHAR(50)  NOT NULL,RevokedByIp VARCHAR(50) );
DROP INDEX IF EXISTS "PK_UserTokens";
ALTER TABLE UserTokens ADD CONSTRAINT "PK_UserTokens" PRIMARY KEY (UserTokenId);

