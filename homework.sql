/*
 Navicat Premium Data Transfer

 Source Server         : Project
 Source Server Type    : MySQL
 Source Server Version : 80028
 Source Host           : localhost:3306
 Source Schema         : homework

 Target Server Type    : MySQL
 Target Server Version : 80028
 File Encoding         : 65001

 Date: 10/06/2022 14:47:58
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for __efmigrationshistory
-- ----------------------------
DROP TABLE IF EXISTS `__efmigrationshistory`;
CREATE TABLE `__efmigrationshistory`  (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of __efmigrationshistory
-- ----------------------------
INSERT INTO `__efmigrationshistory` VALUES ('20220610035654_Migrations', '5.0.17');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` char(36) CHARACTER SET ascii COLLATE ascii_general_ci NOT NULL,
  `username` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `password` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `firstname` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `lastname` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL,
  `bith` datetime(6) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('08da4a98-45fb-460b-85da-87af87cb5a42', 'string', '115116114105110103', 'string', 'string', 'string', '2022-06-10 04:18:26.043000');
INSERT INTO `user` VALUES ('08da4a98-4c0c-4949-810b-f6160b8b635a', 'string1', '115116114105110103', 'string', 'string', 'string1', '2022-06-10 04:18:26.043000');
INSERT INTO `user` VALUES ('08da4a98-5219-440a-82cf-4c6992d0cb9c', 'string21', '115116114105110103', 'string', 'string', 'string12', '2022-06-10 04:18:26.043000');

SET FOREIGN_KEY_CHECKS = 1;
