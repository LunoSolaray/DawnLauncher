namespace OpenLauncher
{
    /// <summary>
    /// 换名字、换仓库、换维护者，只改这一个文件。
    /// 本文件当前为 DawnLauncher —— OpenLauncher 的独立分支（GPL-3.0）。
    /// 改名只需改这里的 AppName / DisplayName / Tagline / RepoUrl，再改 README 与 docs/index.html。
    /// </summary>
    public static class Branding
    {
        public const string AppName = "DawnLauncher";
        public const string DisplayName = "DawnLauncher";
        public const string Tagline = "去中心化的 Minecraft 启动器 · OpenLauncher 的独立分支";

        /// <summary>主页 / 源码下载（仅用于"关于"页面和 User-Agent，不是更新的唯一来源）</summary>
        public const string RepoUrl = "https://github.com/LunoSolaray/DawnLauncher";

        /// <summary>
        /// 内置的更新清单地址。**发布自己的版本之前必须换成你自己的地址。**
        /// 留空 = 这个版本不接受任何自动更新（设置页会提示"没有内置发布公钥"），这是安全默认值：
        /// 不继承上游的更新通道，避免别人的清单、别人的钥匙出现在你的发行版里。
        /// 填法示例（顺序不代表优先级，会全部尝试并取版本最高的有效清单）：
        ///   "https://raw.githubusercontent.com/LunoSolaray/DawnLauncher/main/release/update.json",
        ///   "https://cdn.jsdelivr.net/gh/LunoSolaray/DawnLauncher@main/release/update.json",
        /// </summary>
        public static readonly string[] DefaultUpdateSources = { };

        /// <summary>
        /// 内置信任的发布公钥（RSA，.NET XML 格式）。用 tools/Release 的 keygen 生成。
        /// 含 "@@" 的占位会被忽略 —— 生成自己的钥匙后，把 public-key.xml 的内容替换掉下面这一行。
        /// 私钥离线保存，永远不要提交到仓库。
        /// </summary>
        public static readonly string[] TrustedKeys =
        {
            // @@ 把 public-key.xml 的内容粘贴到下面这一行的位置（保留引号）
            "@@REPLACE-WITH-YOUR-PUBLIC-KEY.XML@@",
        };

        /// <summary>
        /// 微软正版登录用的 Azure 应用 Client ID。
        /// 需要自己在 Azure 注册应用并向 Mojang 申请 Minecraft API 白名单后填入；
        /// 留空时用户可在 设置 → 账户 里填自己的（但同样需要该 ID 已被批准）。
        /// </summary>
        public const string DefaultMicrosoftClientId = "";

        /// <summary>CurseForge API Key（可选）。留空时自动走无需 Key 的镜像。</summary>
        public const string DefaultCurseForgeApiKey = "";
    }
}
