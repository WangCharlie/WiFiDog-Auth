/*
Navicat SQLite Data Transfer

Source Server         : Local(SQLite)
Source Server Version : 30808
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30808
File Encoding         : 65001

Date: 2015-11-16 01:16:45
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for connection
-- ----------------------------
DROP TABLE IF EXISTS "main"."connection";
CREATE TABLE "connection" (
"id"  INTEGER(20) NOT NULL,
"node_id"  INTEGER(20) NOT NULL,
"token"  TEXT(255) NOT NULL,
"status"  TEXT(255) NOT NULL,
"mac"  TEXT(255),
"ip"  TEXT(255),
"auth_type"  TEXT(255),
"identity"  TEXT(255),
"incoming"  REAL(18,2),
"outgoing"  REAL(18,2),
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
"auth_sub_type"  TEXT,
"user_agent"  TEXT,
"disconnect_reason"  TEXT,
PRIMARY KEY ("id"),
FOREIGN KEY ("node_id") REFERENCES "node" ("id")
);

-- ----------------------------
-- Records of connection
-- ----------------------------
INSERT INTO "main"."connection" VALUES (1, 1, '403c6b5361574368e547ddb9c2fd52aef419529c', 'EXPIRED', '9ca9e41981f3', '192.168.199.4', 'apAuthLocalUser', 'jiangzm', 620552576.0, 56541472.0, '2015-09-01 18:34:43', '2015-09-08 09:27:18', 'Authenticated', 'Mozilla/5.0 (Linux; U; Android 4.3; zh-cn; ZTE Q801U Build/JLS36C) AppleWebKit/537.36 (KHTML, like Gecko)Version/4.0 MQQBrowser/6.1 Mobile Safari/537.36', null);
INSERT INTO "main"."connection" VALUES (2, 1, 'b36c8566a4345c17fb2a97b44cd237867876b971', 'LOGGED_OUT', '38f889de00d2', '192.168.199.218', 'apAuthLocalUser', 'jiangzm', 2005291904.0, 72338256.0, '2015-09-05 16:35:41', '2015-09-07 17:46:50', 'Authenticated', 'Mozilla/5.0 (Linux; U; Android 4.2.2; zh-cn; Hol-T00 Build/HUAWEIHol-T00) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Mobile Safari/534.30', '');
INSERT INTO "main"."connection" VALUES (3, 1, '12a866fb0c0299797ee6be51bebfe8009e363e37', 'EXPIRED', '90b686eb82ab', '192.168.199.185', 'apAuthLocalUser', 'jiangzm', 1616829952.0, 30373884.0, '2015-09-06 01:08:38', '2015-09-06 18:14:43', 'Authenticated', 'Mozilla/5.0 (Linux; Android 5.1.1; SM-G9200 Build/LMY47X; wv) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/43.0.2357.121 Mobile Safari/537.36', null);
INSERT INTO "main"."connection" VALUES (4, 1, '2d0dc0d91e0db7e9571053dcd49f4922f0d89b70', 'EXPIRED', '9ca9e41981f3', '192.168.199.4', 'apAuthLocalUser', 'jiangzm', 3509793536.0, 126005248.0, '2015-09-09 01:49:27', '2015-09-21 01:48:31', 'Authenticated', 'Mozilla/5.0 (Linux; U; Android 4.3; zh-cn; ZTE Q801U Build/JLS36C) AppleWebKit/537.36 (KHTML, like Gecko)Version/4.0 MQQBrowser/6.1 Mobile Safari/537.36', null);
INSERT INTO "main"."connection" VALUES (5, 1, 'cb4abc67171b5cd44676134c92b8a0375a0f4fcc', 'LOGGED_OUT', '9ca9e41981f3', '192.168.199.4', 'apAuthLocalUser', 'jiangzm', 93665736.0, 5590695.0, '2015-09-21 01:51:12', '2015-09-23 08:58:30', 'Authenticated', 'Mozilla/5.0 (Linux; U; Android 4.3; zh-cn; ZTE Q801U Build/JLS36C) AppleWebKit/537.36 (KHTML, like Gecko)Version/4.0 MQQBrowser/6.1 Mobile Safari/537.36', '');
INSERT INTO "main"."connection" VALUES (6, 1, '1d307439456dfce9eeb391f9ed64eb7ac300c132', 'EXPIRED', '9ca9e41981f3', '192.168.199.4', 'apAuthLocalUser', 'jiangzm', 781997696.0, 34334168.0, '2015-09-24 07:14:45', '2015-09-26 18:58:29', 'Authenticated', 'Mozilla/5.0 (Linux; U; Android 4.3; zh-cn; ZTE Q801U Build/JLS36C) AppleWebKit/537.36 (KHTML, like Gecko)Version/4.0 MQQBrowser/6.1 Mobile Safari/537.36', null);
INSERT INTO "main"."connection" VALUES (7, 1, 'dfab0d9b97668a1c08e44fc3a640b3854c87ef2c', 'EXPIRED', '5cadcf57f10b', '192.168.199.217', 'apAuthLocalUser', 'jiangzm', 909465536.0, 27109180.0, '2015-09-25 23:51:17', '2015-09-26 14:18:33', 'Authenticated', 'Mozilla/5.0 (iPhone; CPU iPhone OS 9_0 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13A342', null);
INSERT INTO "main"."connection" VALUES (8, 1, '02fb482e4ce1ddfe7ee2a806718b7926c7351c83', 'EXPIRED', '5cadcf57f10b', '192.168.199.217', 'apAuthLocalUser', 'jiangzm', 945565376.0, 42823308.0, '2015-09-26 17:35:14', '2015-09-26 22:58:25', 'Authenticated', 'Mozilla/5.0 (iPhone; CPU iPhone OS 9_0 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13A342', null);
INSERT INTO "main"."connection" VALUES (9, 1, '346d90c459afc2d998fe16bfd02b164dddaae804', 'EXPIRED', '5cadcf57f10b', '192.168.199.217', 'apAuthLocalUser', 'jiangzm', 0.0, 0.0, '2015-09-27 15:23:13', '2015-09-27 16:57:25', 'Authenticated', 'Mozilla/5.0 (iPhone; CPU iPhone OS 9_0_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13A405', null);
INSERT INTO "main"."connection" VALUES (10, 1, 'b90c873738be92a4fca7ea1f788bab3824bf3475', 'EXPIRED', '5cadcf57f10b', '192.168.199.217', 'apAuthLocalUser', 'jiangzm', 0.0, 0.0, '2015-09-27 15:23:15', '2015-09-27 16:57:25', 'Authenticated', 'Mozilla/5.0 (iPhone; CPU iPhone OS 9_0_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13A405', null);
INSERT INTO "main"."connection" VALUES (11, 1, '859c8a43de70784617b0b22bf0424dc55781ebd8', 'EXPIRED', '5cadcf57f10b', '192.168.199.217', 'apAuthLocalUser', 'jiangzm', 823035.0, 270012.0, '2015-09-27 15:23:16', '2015-09-27 16:57:25', 'Authenticated', 'Mozilla/5.0 (iPhone; CPU iPhone OS 9_0_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13A405', null);
INSERT INTO "main"."connection" VALUES (12, 1, '2efcb993357d21337d17c7e406a6b20e36cf5fd8', 'LOGGED_OUT', '5cadcf57f10b', '192.168.199.217', 'apAuthLocalUser', 'jiangzm', 530775392.0, 23053000.0, '2015-09-30 21:46:23', '2015-10-02 20:37:19', 'Authenticated', 'Mozilla/5.0 (iPhone; CPU iPhone OS 9_0_1 like Mac OS X) AppleWebKit/601.1.46 (KHTML, like Gecko) Mobile/13A405', '');
INSERT INTO "main"."connection" VALUES (13, 1, '4ad772a1bcb176f13890a0a16cf121234a125efa', 'EXPIRED', 'dc0ea1d561cd', '192.168.199.233', 'apAuthLocalUser', 'jiangzm', 218790096.0, 11408384.0, '2015-10-02 20:16:16', '2015-10-05 20:23:11', 'Authenticated', 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/42.0.2311.135 Safari/537.36 Edge/12.10240', null);
INSERT INTO "main"."connection" VALUES (14, 1, 'c2f6bfdde11bf71d2737e97eeb98d8aad89edb01', 'TOKEN_VALIDATED', '38bc1acc78f8', '192.168.199.208', 'apAuthLocalUser', 'jiangzm', 21491528.0, 2246244.0, '2015-10-05 20:28:02', '2015-10-05 23:53:33', 'Authenticated', 'Mozilla/5.0 (Linux; U; Android 5.0.1; zh-cn; MX4 Pro Build/LRX22C) AppleWebKit/537.36 (KHTML, like Gecko)Version/4.0 MQQBrowser/6.1 Mobile Safari/537.36', null);

-- ----------------------------
-- Table structure for forgot_password
-- ----------------------------
DROP TABLE IF EXISTS "main"."forgot_password";
CREATE TABLE "forgot_password" (
"id"  INTEGER(20) NOT NULL,
"user_id"  INTEGER(20) NOT NULL,
"unique_key"  TEXT(255),
"expires_at"  TEXT NOT NULL,
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("id"),
FOREIGN KEY ("user_id") REFERENCES "user" ("id")
);

-- ----------------------------
-- Records of forgot_password
-- ----------------------------

-- ----------------------------
-- Table structure for group
-- ----------------------------
DROP TABLE IF EXISTS "main"."group";
CREATE TABLE "group" (
"id"  INTEGER(20) NOT NULL,
"name"  TEXT(255),
"description"  TEXT,
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("id")
);

-- ----------------------------
-- Records of group
-- ----------------------------
INSERT INTO "main"."group" VALUES (1, 'admin', 'Administrator group', '2015-09-01 18:16:23', '2015-09-01 18:16:23');
INSERT INTO "main"."group" VALUES (2, 'support', 'Support group', '2015-09-01 18:16:23', '2015-09-01 18:16:23');

-- ----------------------------
-- Table structure for group_permission
-- ----------------------------
DROP TABLE IF EXISTS "main"."group_permission";
CREATE TABLE "group_permission" (
"group_id"  INTEGER(20) NOT NULL,
"permission_id"  INTEGER(20) NOT NULL,
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("group_id", "permission_id"),
FOREIGN KEY ("group_id") REFERENCES "group" ("id"),
FOREIGN KEY ("permission_id") REFERENCES "permission" ("id")
);

-- ----------------------------
-- Records of group_permission
-- ----------------------------
INSERT INTO "main"."group_permission" VALUES (1, 1, '2015-09-01 18:16:23', '2015-09-01 18:16:23');
INSERT INTO "main"."group_permission" VALUES (1, 2, '2015-09-01 18:16:23', '2015-09-01 18:16:23');
INSERT INTO "main"."group_permission" VALUES (2, 2, '2015-09-01 18:16:23', '2015-09-01 18:16:23');

-- ----------------------------
-- Table structure for member
-- ----------------------------
DROP TABLE IF EXISTS "main"."member";
CREATE TABLE "member" (
"id"  INTEGER(20) NOT NULL,
"username"  TEXT(50) NOT NULL,
"password"  TEXT(50) NOT NULL,
"email"  TEXT(255) NOT NULL,
"registered_on"  TEXT NOT NULL,
"validation_token"  TEXT(40),
"status"  INTEGER(4),
"username_lower"  TEXT(50),
PRIMARY KEY ("id")
);

-- ----------------------------
-- Records of member
-- ----------------------------
INSERT INTO "main"."member" VALUES (1, 'jiangzm', 'JdVa0oOqQAr0ZMdtcTwHrQ==', 'jiang_zm@qq.com', '2015-09-01 18:25:02', '82d9e68f4c93be43fd7303c81e7c695d2a3b1304', 1, 'jiangzm');

-- ----------------------------
-- Table structure for node
-- ----------------------------
DROP TABLE IF EXISTS "main"."node";
CREATE TABLE "node" (
"id"  INTEGER(20) NOT NULL,
"name"  TEXT(150) NOT NULL,
"gw_id"  TEXT(50) NOT NULL,
"last_heartbeat_at"  TEXT,
"last_heartbeat_ip"  TEXT(255),
"last_heartbeat_sys_uptime"  INTEGER(20),
"last_heartbeat_sys_memfree"  INTEGER(20),
"last_heartbeat_sys_load"  REAL(18,2),
"last_heartbeat_wifidog_uptime"  INTEGER(20),
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
"description"  TEXT,
"civic_number"  TEXT(20),
"street_name"  TEXT(150),
"city"  TEXT(150),
"province"  TEXT(150),
"country"  TEXT(150),
"postal_code"  TEXT(15),
"public_phone_number"  TEXT(50),
"public_email"  TEXT(150),
"mass_transit_info"  TEXT,
"deployment_status"  TEXT(20),
PRIMARY KEY ("id")
);

-- ----------------------------
-- Records of node
-- ----------------------------
INSERT INTO "main"."node" VALUES (1, 'My first node', 'default', '2015-10-05 23:53:34', '192.168.199.1', 16287, 45816, 0.0, 601, '2015-09-01 18:16:23', '2015-10-05 23:53:34', null, null, null, null, null, null, null, null, null, null, null);

-- ----------------------------
-- Table structure for permission
-- ----------------------------
DROP TABLE IF EXISTS "main"."permission";
CREATE TABLE "permission" (
"id"  INTEGER(20) NOT NULL,
"name"  TEXT(255),
"description"  TEXT,
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("id")
);

-- ----------------------------
-- Records of permission
-- ----------------------------
INSERT INTO "main"."permission" VALUES (1, 'admin', 'Administrator permission', '2015-09-01 18:16:23', '2015-09-01 18:16:23');
INSERT INTO "main"."permission" VALUES (2, 'support', 'Support permission', '2015-09-01 18:16:23', '2015-09-01 18:16:23');

-- ----------------------------
-- Table structure for remember_key
-- ----------------------------
DROP TABLE IF EXISTS "main"."remember_key";
CREATE TABLE "remember_key" (
"id"  INTEGER(20) NOT NULL,
"user_id"  INTEGER(20),
"remember_key"  TEXT(32),
"ip_address"  TEXT(50),
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("id"),
FOREIGN KEY ("user_id") REFERENCES "user" ("id")
);

-- ----------------------------
-- Records of remember_key
-- ----------------------------

-- ----------------------------
-- Table structure for remember_me
-- ----------------------------
DROP TABLE IF EXISTS "main"."remember_me";
CREATE TABLE "remember_me" (
"id"  INTEGER(20) NOT NULL,
"member_id"  INTEGER(20) NOT NULL,
"remember_me_cookie"  TEXT(50) NOT NULL,
PRIMARY KEY ("id"),
FOREIGN KEY ("member_id") REFERENCES "member" ("id")
);

-- ----------------------------
-- Records of remember_me
-- ----------------------------
INSERT INTO "main"."remember_me" VALUES (1, 1, '39406acd5836d30d9bdae2d8cca3066374c25a98');
INSERT INTO "main"."remember_me" VALUES (2, 1, 'f79febdff6868971ccf04028a4146d5c39a209af');
INSERT INTO "main"."remember_me" VALUES (3, 1, '3bbddb31260e599de4a16e238794b266e97164fe');
INSERT INTO "main"."remember_me" VALUES (4, 1, '3050893128e61b9640263b4339a70e3ce8281a77');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS "main"."user";
CREATE TABLE "user" (
"id"  INTEGER(20) NOT NULL,
"first_name"  TEXT(255),
"last_name"  TEXT(255),
"email_address"  TEXT(255) NOT NULL,
"username"  TEXT(128) NOT NULL,
"algorithm"  TEXT(128) NOT NULL,
"salt"  TEXT(128),
"password"  TEXT(128),
"is_active"  INTEGER(1),
"is_super_admin"  INTEGER(1),
"last_login"  TEXT,
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("id")
);

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO "main"."user" VALUES (1, 'Michael', 'Jiang', 'admin@jiangzm.com', 'admin', 'sha1', '62af4691c4a3b258bb01cbcebe9a047f', 'c395d03f5bff4a931ebab1dbc78b6b475e1383d2', 1, 1, '2015-10-05 23:18:35', '2015-09-01 18:16:45', '2015-10-05 23:18:35');

-- ----------------------------
-- Table structure for user_group
-- ----------------------------
DROP TABLE IF EXISTS "main"."user_group";
CREATE TABLE "user_group" (
"user_id"  INTEGER(20) NOT NULL,
"group_id"  INTEGER(20) NOT NULL,
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("user_id", "group_id"),
FOREIGN KEY ("group_id") REFERENCES "group" ("id"),
FOREIGN KEY ("user_id") REFERENCES "user" ("id")
);

-- ----------------------------
-- Records of user_group
-- ----------------------------

-- ----------------------------
-- Table structure for user_permission
-- ----------------------------
DROP TABLE IF EXISTS "main"."user_permission";
CREATE TABLE "user_permission" (
"user_id"  INTEGER(20) NOT NULL,
"permission_id"  INTEGER(20) NOT NULL,
"created_at"  TEXT NOT NULL,
"updated_at"  TEXT NOT NULL,
PRIMARY KEY ("user_id", "permission_id"),
FOREIGN KEY ("permission_id") REFERENCES "permission" ("id"),
FOREIGN KEY ("user_id") REFERENCES "user" ("id")
);

-- ----------------------------
-- Records of user_permission
-- ----------------------------

-- ----------------------------
-- Indexes structure for table connection
-- ----------------------------
CREATE INDEX "main"."idx_connection_created_at"
ON "connection" ("created_at" ASC);
CREATE INDEX "main"."idx_connection_identity"
ON "connection" ("auth_type" ASC, "identity" ASC);
CREATE INDEX "main"."idx_connection_node_id"
ON "connection" ("node_id" ASC);
CREATE UNIQUE INDEX "main"."idx_connection_token"
ON "connection" ("token" ASC);

-- ----------------------------
-- Indexes structure for table forgot_password
-- ----------------------------
CREATE INDEX "main"."idx_forgot_password_user_id"
ON "forgot_password" ("user_id" ASC);

-- ----------------------------
-- Indexes structure for table group
-- ----------------------------
CREATE UNIQUE INDEX "main"."idx_group_name"
ON "group" ("name" ASC);

-- ----------------------------
-- Indexes structure for table group_permission
-- ----------------------------
CREATE INDEX "main"."idx_group_permission_permission_id"
ON "group_permission" ("permission_id" ASC);

-- ----------------------------
-- Indexes structure for table member
-- ----------------------------
CREATE UNIQUE INDEX "main"."idx_member_email"
ON "member" ("email" ASC);
CREATE UNIQUE INDEX "main"."idx_member_username"
ON "member" ("username" ASC);
CREATE INDEX "main"."idx_member_username_lower"
ON "member" ("username_lower" ASC);

-- ----------------------------
-- Indexes structure for table node
-- ----------------------------
CREATE UNIQUE INDEX "main"."idx_node_gw_id"
ON "node" ("gw_id" ASC);

-- ----------------------------
-- Indexes structure for table permission
-- ----------------------------
CREATE UNIQUE INDEX "main"."idx_permission_name"
ON "permission" ("name" ASC);

-- ----------------------------
-- Indexes structure for table remember_key
-- ----------------------------
CREATE INDEX "main"."idx_remember_key_user_id"
ON "remember_key" ("user_id" ASC);

-- ----------------------------
-- Indexes structure for table remember_me
-- ----------------------------
CREATE INDEX "main"."idx_remember_me_cookie"
ON "remember_me" ("remember_me_cookie" ASC);
CREATE INDEX "main"."idx_remember_me_member_id"
ON "remember_me" ("member_id" ASC);

-- ----------------------------
-- Indexes structure for table user
-- ----------------------------
CREATE UNIQUE INDEX "main"."idx_user_email_address"
ON "user" ("email_address" ASC);
CREATE INDEX "main"."idx_user_is_active"
ON "user" ("is_active" ASC);
CREATE UNIQUE INDEX "main"."idx_user_username"
ON "user" ("username" ASC);

-- ----------------------------
-- Indexes structure for table user_group
-- ----------------------------
CREATE INDEX "main"."idx_user_group_group_id"
ON "user_group" ("group_id" ASC);

-- ----------------------------
-- Indexes structure for table user_permission
-- ----------------------------
CREATE INDEX "main"."idx_user_permission_permission_id"
ON "user_permission" ("permission_id" ASC);
