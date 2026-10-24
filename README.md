# DawnLauncher

[![build](https://github.com/LunoSolaray/DawnLauncher/actions/workflows/build.yml/badge.svg)](https://github.com/LunoSolaray/DawnLauncher/actions/workflows/build.yml)

A free, open-source launcher for **Minecraft: Java Edition** on Windows 10/11.
Independent fork of OpenLauncher (GPL-3.0).

- **Website & download:** https://lunosolaray.github.io/DawnLauncher/
- **Releases (exe + SHA-256):** https://github.com/LunoSolaray/DawnLauncher/releases
- **Privacy policy:** https://lunosolaray.github.io/DawnLauncher/privacy.html
- **Terms of use:** https://lunosolaray.github.io/DawnLauncher/terms.html
- **Contact:** DreemurrDawnlit@outlook.com
- **License:** GPL-3.0 — see [LICENSE](LICENSE) and [NOTICE](NOTICE)

## What it is

A desktop launcher that downloads and starts Minecraft: Java Edition, manages multiple
instances, installs mod loaders (Forge, NeoForge, Fabric, Quilt, OptiFine), searches and
installs mods and modpacks from Modrinth and CurseForge, and signs players in with their
own account.

## What it is not

- It is **not affiliated with, endorsed by, or sponsored by** Mojang Studios or Microsoft.
- It does **not** contain, host, mirror or redistribute Minecraft game files. Client jars,
  assets and libraries are downloaded from Mojang's official servers (or public mirrors of
  those same files) into the player's own folder, at the player's request.
- It does **not** bypass authentication, and it cannot create, crack or share accounts.
  Online play requires a genuine Microsoft account that owns Minecraft: Java Edition.

## Microsoft account sign-in

Sign-in uses the official Microsoft identity platform flow: OAuth 2.0 device
authorization grant (public client, tenant `consumers`, scope `XboxLive.signin`), then
Xbox Live, then XSTS, then:

- `POST https://api.minecraftservices.com/authentication/login_with_xbox` — to obtain the
  player's own Minecraft access token;
- `GET https://api.minecraftservices.com/minecraft/profile` — to confirm Java Edition
  ownership and read that player's own UUID, username and skin.

No other Minecraft Services endpoints are used. Access to those endpoints requires an
**approved application (client) ID**; details and the current status are documented in
[docs/微软登录.md](docs/微软登录.md).

## Privacy

No telemetry, no analytics, no account backend. The only account data stored is the
refresh token, kept on the user's machine and encrypted with Windows DPAPI under the
current Windows user. Full text: [privacy policy](https://lunosolaray.github.io/DawnLauncher/privacy.html).

## Build

Requires the .NET SDK 8 or newer (no Visual Studio needed):

```powershell
.\build.ps1        # outputs dist\DawnLauncher.exe
```

Every push to `main` is built automatically by GitHub Actions, and a tag `v*` publishes
the executable to Releases with its SHA-256 in the release notes. Releases, update-manifest
signing, key rotation and community hand-over are documented in
[docs/发布与接手.md](docs/发布与接手.md).

## Fork and credits

This is an independent fork of **OpenLauncher** (decentralized Minecraft launcher,
GPL-3.0). The build this fork is based on came from a public community download page, not
from the copyright holder. Original copyright notices and the GPL-3.0
license are retained. Changes in this fork: rebranding, an independent update channel and
signing key, and an independent website and release process. See [NOTICE](NOTICE).

Minecraft is a trademark of Mojang Synergies AB.

---

# DawnLauncher（中文）

去中心化的 Minecraft Java 版启动器，免费、开源，**OpenLauncher 的独立分支**（GPL-3.0）。

- 下载页面：https://lunosolaray.github.io/DawnLauncher/
- 发布页（exe + SHA-256）：https://github.com/LunoSolaray/DawnLauncher/releases
- 联系邮箱：DreemurrDawnlit@outlook.com

## 功能

| 模块 | 功能 |
|---|---|
| 启动 | 一键启动；自动补全缺失文件；自动选择 / 下载合适的 Java；自动分配内存；版本隔离；自定义窗口标题、窗口大小、全屏；启动后自动进服；启动后最小化 / 隐藏 / 关闭；实时游戏日志；导出启动脚本 |
| 账号 | 离线账号；微软正版（设备代码登录，需要已获批的 Client ID）；外置登录（authlib-injector，LittleSkin / Blessing Skin 等）；皮肤头像 |
| 下载游戏 | 正式版 / 快照 / 远古版 / 愚人节版；Forge、NeoForge、Fabric（可同时装 Fabric API）、Quilt；自己执行 Forge 安装器的处理器，下载可走镜像 |
| 社区资源 | Modrinth + CurseForge 双源搜索 Mod / 整合包 / 资源包 / 光影包 / 数据包；常见中文名搜索；自动补齐前置 Mod；按版本和加载器筛选 |
| 整合包 | 导入 Modrinth（.mrpack）和 CurseForge（.zip）整合包；导出为 .mrpack |
| 管理 | 多个 .minecraft 目录；版本重命名 / 删除（进回收站）/ 描述；Mod 启用禁用、批量检查更新、一键更新；资源包 / 光影 / 存档 / 截图管理，支持拖放安装 |
| 崩溃分析 | 识别内存不足、Java 版本不对、缺前置、重复 Mod、Mixin 冲突、显卡驱动等常见原因并给建议；一键导出错误报告 |
| 下载 | 多线程、断点换源、全部文件校验；BMCLAPI / MCIM 镜像与官方源错峰竞速，自动避开连不上的源；可自定义镜像；限速 |
| 个性化 | 主题色、背景图 |
| 更新 | 多更新源并行拉取签名清单；可添加信任的发布者公钥；镜像表可随签名清单下发 |

## 下载使用

从 https://lunosolaray.github.io/DawnLauncher/ 下载 `DawnLauncher.exe`，放进一个空文件夹双击即可
（Windows 10 / 11 自带 .NET Framework 4.8，无需安装任何东西）。
游戏文件默认放在 exe 旁边的 `.minecraft`，启动器配置在 `DawnLauncher` 文件夹里——整个文件夹拷走就能在别的电脑上用。

也可以在 **版本选择 → 添加已有的游戏目录** 里直接使用官方启动器、PCL、HMCL 的 `.minecraft`。

## 自己编译

只需要 [.NET SDK](https://dotnet.microsoft.com/download)（8 或更新），不需要 Visual Studio：

```powershell
.\build.ps1        # 输出 dist\DawnLauncher.exe
```

## 去中心化是怎么做到的

```
           官方源                       公益镜像（可增删）
  Mojang / Forge / NeoForge /     BMCLAPI / MCIM / 你自己加的
  Fabric / Quilt / Modrinth /  ⇄  ─────────────────────────
  CurseForge                      错峰竞速，谁快用谁，失败自动换
                 ╲                   ╱
                  ╲                 ╱
                   DawnLauncher.exe
                  ╱                 ╲
 签名更新清单（GitHub / jsDelivr / Gitee / 任何人的镜像）
   ↑ 只认被信任公钥签名的清单；exe 用 SHA-256 校验
```

- 改名、换仓库、换维护者都只需要改 `src/OpenLauncher/Branding.cs` 一个文件。
- 发版流程、钥匙轮换、社区接手：见 [docs/发布与接手.md](docs/发布与接手.md)。
- 微软登录需要自己申请 Client ID：见 [docs/微软登录.md](docs/微软登录.md)。

## 项目结构

```
src/OpenLauncher/
  Core/       JSON、HTTP、镜像表、多线程下载器、设置、任务
  Game/       版本 JSON 合并、安装器（原版 / Fabric / Quilt / Forge / NeoForge）、启动参数、Java 管理、崩溃分析
  Accounts/   离线 / 微软 / 外置登录、authlib-injector、皮肤
  Content/    Modrinth / CurseForge、本地 Mod 管理、整合包导入导出
  Update/     签名清单与自更新
  UI/         WPF 界面
tools/Release/  发布工具：生成密钥、签名清单、校验
docs/           维护文档
```

## 声明

本项目与 Mojang、Microsoft 无关，Minecraft 是 Mojang Synergies AB 的商标。
本项目是 OpenLauncher 的独立分支，原作者版权声明与 GPL-3.0 许可均予保留，详见 [NOTICE](NOTICE)。
镜像服务由 bangbang93（BMCLAPI）、MCIM 等社区成员公益提供，请合理使用。
