# 七日杀Mod管理器 (7 Days to Die Mod Manager)

一个专为《7 Days to Die》游戏开发的Mod管理工具，采用C# Windows Forms构建，为玩家提供简单易用的模组管理解决方案。

## 🎮 项目概述

七日杀Mod管理器是一个桌面应用程序，旨在简化《7 Days to Die》游戏的模组安装、管理和备份流程。通过图形化界面让玩家能够轻松管理游戏模组，无需手动操作复杂的文件目录。

## ✨ 核心功能

### 已实现功能
- **🗂️ 模组管理** - 统一管理游戏模组文件
- **📦 存档管理** - 游戏存档的备份和恢复功能  
- **⚙️ 游戏设置** - 游戏参数配置管理
- **📥 文件下载** - 集成下载功能支持
- **🔄 文件传输** - 模组文件的复制和移动操作
- **📚 参考手册** - 内置游戏和模组使用指南
- **💾 存档备份** - 自动备份重要游戏数据

### 主要模块
- **主界面 (Form1)** - 程序主控制面板
- **存档管理器 (ArchiveManager)** - 存档备份和恢复
- **备份窗口 (BackupWindow)** - 备份操作界面
- **下载窗口 (DownWindows)** - 文件下载管理
- **游戏设置 (GameSettingWindow)** - 游戏参数配置
- **文件传输 (TransferFiles)** - 模组文件操作
- **参考手册 (ReferenceBook)** - 帮助文档查看
- **设置修改 (ModifySetting)** - 应用程序设置

## 🚀 安装使用

### 系统要求
- **操作系统**: Windows 10/11
- **运行环境**: .NET Framework 4.7.2+
- **游戏要求**: 7 Days to Die 游戏本体
- **磁盘空间**: 至少50MB可用空间

### 安装步骤
1. 从 [Releases](https://github.com/qq7995516/7-Days-to-Die-Mod-Manager/releases) 下载最新版本
2. 解压到目标目录
3. 运行 `七日杀Mod管理器.exe`
4. 首次启动时配置游戏安装路径

### 使用指南
1. **初始配置** - 设置7 Days to Die游戏目录
2. **模组导入** - 通过文件浏览器添加模组文件
3. **存档备份** - 定期备份重要存档数据
4. **模组管理** - 启用/禁用所需模组
5. **应用更改** - 确认设置并启动游戏

## 🛠️ 开发信息

### 技术架构
- **开发语言**: C#
- **UI框架**: Windows Forms
- **目标框架**: .NET Framework
- **开发工具**: Visual Studio
- **项目类型**: Windows桌面应用程序

### 项目结构
```
七日杀Mod管理器/
├── Form1.cs                    # 主窗体
├── ArchiveManager.cs           # 存档管理
├── BackupWindow.cs             # 备份窗口
├── DownWindows.cs              # 下载窗口
├── GameSettingWindow.cs        # 游戏设置
├── TransferFiles.cs            # 文件传输
├── ReferenceBook.cs            # 参考手册
├── ModifySetting.cs            # 设置修改
├── Tool.cs                     # 工具类库
├── Tips.cs                     # 提示窗口
└── Program.cs                  # 程序入口
```

### 本地构建
```bash
# 克隆项目
git clone https://github.com/qq7995516/7-Days-to-Die-Mod-Manager.git
cd 7-Days-to-Die-Mod-Manager

# 使用Visual Studio打开
# 打开 七日杀Mod管理器.sln 解决方案文件
# 选择 Release 配置并构建项目
```

## 🤝 参与贡献

欢迎提交Issue和Pull Request！

### 贡献流程
1. Fork本仓库
2. 创建特性分支 (`git checkout -b feature/新功能`)
3. 提交修改 (`git commit -m '添加某某功能'`)
4. 推送分支 (`git push origin feature/新功能`)
5. 创建Pull Request

### 开发规范
- 遵循C#编码规范
- 添加必要的代码注释
- 测试新功能的稳定性
- 更新相关文档

## 📋 版本历史

### 当前版本
- ✅ 基础模组管理功能
- ✅ 存档备份恢复系统
- ✅ 游戏设置配置界面
- ✅ 文件下载和传输功能
- ✅ 参考手册集成

## ⚠️ 使用须知

- **备份重要** - 使用前请备份游戏存档和配置文件
- **模组安全** - 仅安装来源可靠的模组文件
- **版本兼容** - 注意模组与游戏版本的兼容性
- **游戏关闭** - 安装模组前请完全关闭游戏进程
- **管理员权限** - 某些操作可能需要管理员权限

## 🐛 问题报告

遇到问题请按以下步骤：

1. 查看 [Issues页面](https://github.com/qq7995516/7-Days-to-Die-Mod-Manager/issues) 是否有相似问题
2. 创建新Issue并提供以下信息：
   - 详细的问题描述
   - 操作系统版本
   - 游戏版本信息
   - 错误截图或日志
   - 复现步骤

## 📄 开源协议

本项目基于 [MIT License](LICENSE.txt) 开源协议发布。

## 🎯 未来计划

- [ ] 自动模组更新检测
- [ ] 模组冲突检测机制
- [ ] 云端存档同步功能
- [ ] 模组推荐系统
- [ ] 多语言界面支持

## 💖 特别感谢

感谢所有为项目贡献代码、提出建议和报告问题的开发者和用户！

---

**免责声明**: 本工具仅供个人学习和研究使用，使用过程中的任何风险由用户自行承担。请确保遵守游戏相关条款和当地法律法规。
