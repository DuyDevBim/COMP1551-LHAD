-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: localhost
-- Thời gian đã tạo: Th4 25, 2025 lúc 07:17 PM
-- Phiên bản máy phục vụ: 10.4.28-MariaDB
-- Phiên bản PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `stringdb`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `encoded_strings`
--

CREATE TABLE `encoded_strings` (
  `id` int(11) NOT NULL,
  `original_string` varchar(40) DEFAULT NULL,
  `shift` int(11) DEFAULT NULL,
  `encoded_string` varchar(40) DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `encoded_strings`
--

INSERT INTO `encoded_strings` (`id`, `original_string`, `shift`, `encoded_string`, `created_at`) VALUES
(1, 'ANHDUY', 2, 'CPJFWA', '2025-04-19 12:25:04'),
(2, 'ABC', 2, 'CDE', '2025-04-19 12:35:04'),
(3, 'AVC', 2, 'CXE', '2025-04-19 16:03:33'),
(4, 'ABD', 0, 'ZYW', '2025-04-22 06:20:22'),
(5, 'ABC', 0, 'CBA', '2025-04-22 07:25:48'),
(6, 'ABC', 2, 'CDE', '2025-04-22 07:52:31'),
(7, 'ABC', 2, 'CDE', '2025-04-22 08:23:49'),
(8, 'ABC', 2, 'CDE', '2025-04-22 08:44:46'),
(9, 'ABC', 0, 'ZYX', '2025-04-22 08:44:46'),
(10, 'ABC', 0, 'CBA', '2025-04-22 08:44:46'),
(11, 'HELLO', 2, 'JGNNQ', '2025-04-22 09:43:24'),
(12, 'HELLO', 0, 'SVOOL', '2025-04-22 09:43:24'),
(13, 'HELLO', 0, 'OLLEH', '2025-04-22 09:43:24'),
(14, 'HELLO', 5, 'MJQQT', '2025-04-22 09:46:15'),
(15, 'HELLO', 0, 'SVOOL', '2025-04-22 09:46:15'),
(16, 'HELLO', 0, 'OLLEH', '2025-04-22 09:46:15'),
(17, 'HELLO', 5, 'MJQQT', '2025-04-25 13:33:36'),
(18, 'HELLO', 0, 'SVOOL', '2025-04-25 13:33:36'),
(19, 'HELLO', 0, 'OLLEH', '2025-04-25 13:33:36'),
(20, 'HELLO', 5, 'MJQQT', '2025-04-25 13:40:16'),
(21, 'HELLO', 0, 'SVOOL', '2025-04-25 13:40:16'),
(22, 'HELLO', 0, 'OLLEH', '2025-04-25 13:40:16'),
(23, 'HELLO', 5, 'MJQQT', '2025-04-25 13:43:28'),
(24, 'HELLO', 0, 'SVOOL', '2025-04-25 13:43:28'),
(25, 'HELLO', 0, 'OLLEH', '2025-04-25 13:43:28'),
(26, 'HELLO', 5, 'MJQQT', '2025-04-25 14:03:09'),
(27, 'HELLO', 0, 'SVOOL', '2025-04-25 14:03:09'),
(28, 'HELLO', 0, 'OLLEH', '2025-04-25 14:03:09');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `encoded_strings`
--
ALTER TABLE `encoded_strings`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `encoded_strings`
--
ALTER TABLE `encoded_strings`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=29;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
