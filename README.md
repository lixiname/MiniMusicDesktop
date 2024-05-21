# MiniMusicDesktop

这是一款音乐管理器的纯前端的桌面应用程序，使用 **.NET** 旗下的 **Avalonia** 跨平台UI进行开发,其中使用的MVVM模式为ReavtiveUI。该程序提供了面向桌面的GUI图形界面（既包括web前端如VUE3或桌面前端如**Avalonia**编写的桌面前端），该程序可以和另一个仓库中的后端程序搭配使用。

与音乐管理器配套的MusicManagementsMinimalAPI后端程序同样可从本人的其他仓库中得到。

![图片-音乐管理器桌面应用程序](./Assert/MiniMusicDesktop1.png "前端的音乐收藏界面")

---

### 所需依赖

前端程序所需依赖

运行环境为 **.NET**旗下的 **Avalonia** ,其次还安装了报文解包所需的序列化器包，以及流媒体所依托的**LibSharpLVC**等包，均可使用NuGet进行安装，其中 **Avalonia**涉及的包很多，你可以使用nuget命令来逐一安装这些包，如果你采用的IDE是Visual Studio，那么也可以通过导航栏的  **工具 -> NuGet包管理器 -> 管理解决方案的NuGet程序包 ** 来安装这些依赖包。

```
Avalonia  11.0.10
Avalonia.Desktop  11.0.10
Avalonia.Diagnostics  11.0.10
Avalonia.Fonts.Inter  11.0.10
Avalonia.ReactiveUI  11.0.10
Avalonia.Themes.Fluent  11.0.10
Avalonia.Controls.DataGrid  11.0.10
Dove.Avalonia.Extensions.Media  2.0.2
VideoLAN.LibVLC.Windows  3.0.20
iTunesSearch  1.0.44
Newtonsoft.Json  13.0.3
```


### 运行

1 clone本人仓库的另一个MusicManagementsMinimalAPI后端程序配置后并运行。

2 在Visual Studio中运行MiniMusicDesktop前端项目。


---

### 项目目录

项目目录所涉及的主要文件夹和文件结构

MiniMusicDesktop


|——Assert    *资源文件夹*

|——Models    *数据模型类文件夹*

|——ViewModels    *视图模型文件夹*

|——Views    *视图文件夹*

|——App.axaml    

|——Icons.axaml    *图标资源*

|——Languages.en-US.resx    *国际化语言包*

|——Languages.zh-Hans.resx    *国际化语言包*

|——ViewLocator.cs    *视图定位器*

|——Program.cs    *主程序*



