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

 Date: 13/06/2022 11:19:21
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
INSERT INTO `__efmigrationshistory` VALUES ('20220613034148_Migrations', '5.0.17');

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
INSERT INTO `user` VALUES ('08da4cf2-ef3d-4401-8781-153baeebcd8a', 'string', '115116114105110103', 'string', 'string', 'string', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-03ef-4c4c-8865-94d306f64b3c', 'namso1', '1109710911511149', 'string', 'string', 'namso1', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-06f1-42fe-8075-d9bedf8c1813', 'namso2', '1109710911511149', 'string', 'string', 'namso2', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-0b82-4412-84b0-4415b25fd40d', 'namso3', '1109710911511149', 'string', 'string', 'namso3', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-0fce-461c-83b6-7c12b14f771c', 'namso4', '1109710911511149', 'string', 'string', 'namso4', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-138e-461e-88c5-8588cdf25997', 'namso5', '1109710911511149', 'string', 'string', 'namso5', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-171d-4a3e-83b4-e9c3e0f0326a', 'namso6', '1109710911511149', 'string', 'string', 'namso6', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-1a76-4505-83a6-507269da4145', 'namso7', '1109710911511149', 'string', 'string', 'namso7', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-1eb1-4bee-8802-cbd538d89503', 'namso8', '1109710911511149', 'string', 'string', 'namso8', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-2512-4bb4-895b-dc5e93ef7738', 'namso9', '1109710911511149', 'string', 'string', 'namso9', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-29c3-4b8e-87cc-943302909683', 'namso10', '1109710911511149', 'string', 'string', 'namso10', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-2cef-4c3e-851f-e010371c3013', 'namso11', '1109710911511149', 'string', 'string', 'namso11', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-2fa2-4b9b-8002-897a437b183d', 'namso12', '1109710911511149', 'string', 'string', 'namso12', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-32ed-4e93-8706-0e494559336e', 'namso13', '1109710911511149', 'string', 'string', 'namso13', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-36d2-4b80-8169-844c3bd9d00f', 'namso14', '1109710911511149', 'string', 'string', 'namso14', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-3bcd-4c3f-8b03-3c8ecc9f8298', 'namso16', '1109710911511149', 'string', 'string', 'namso16', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-403a-496a-86ad-d2884f41b653', 'namso15', '1109710911511149', 'string', 'string', 'namso15', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-43db-4b6e-8452-8bf57327af7c', 'namso17', '1109710911511149', 'string', 'string', 'namso17', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-46d9-40c9-8de2-9d3b437b9020', 'namso18', '1109710911511149', 'string', 'string', 'namso18', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-4ac0-455d-876c-5a53021d9101', 'namso19', '1109710911511149', 'string', 'string', 'namso19', '2022-06-13 04:12:28.216000');
INSERT INTO `user` VALUES ('08da4cf3-4ed5-4e55-8e47-4405e9fdbc13', 'namso20', '1109710911511149', 'string', 'string', 'namso20', '2022-06-13 04:12:28.216000');

SET FOREIGN_KEY_CHECKS = 1;
