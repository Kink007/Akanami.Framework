# Akanami 基于 .Net Core的系统框架

    说明：本文档主要是用于记录搭建的框架过程以及框架的使用方法

    注:在编写文档时请使用4个空格表示缩进，而非使用tab进行缩进

## 代码结构

    基本项目的代码主要分为下列工程

    Akanami.{项目}.Infrastructure:项目的基础结构
    Akanami.{项目}.Application:项目的服务层代码
    Akanami.{项目}.Domain:项目的领域模型(项目的数据库模型)
    Akanami.{项目}.EntityFrameworkCore:基于EntityFrameworkCore的数据访问框架
    Akanami.{项目}.ApiHost:Api的托管控制台

## Logger 日志

### log4net日志:

### nlog日志:

## Dependency 依赖注入

### Autofac框架

### Wisdor框架

## 动态Api

## Database 数据访问层

### EntityFrameworkCore

### Dapper

## 系统权限

## 健康检查

## 单元测试

## Docker部署
 