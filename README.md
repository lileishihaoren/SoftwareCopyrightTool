# SoftwareCopyrightTool
This tool is used for applying for software copyright in China. 本工具用于输出适合软件著作权要求的代码格式。

**适用**
目前暂时只支持C#语言。
采用.Net Framework 4.7

**软件著作权对源代码的要求**
1. 代码要求是提供原始的代码，不是关键代码，语法上要求完整。
> 例如C#代码应该是 using 之类开头的，而不是直接一开始就是函数。
2. 第一页应该是以下一种情况所在的页面的原始代码 
> A. 主函数 B. 程序的入口 比如登录函数 C. 主页 比如 index default页面
3. 尽量少提供或者不提供设计器生成的代码。
> 以C#语言为例，设计器生成的代码语言文件，一般为XXXt.designer.cs。
4. 代码量按前、后各连道续30页，共60页。
> （不足60页全部提交）第60页为模块结束页，每页不少于50行（结束页除外）。
