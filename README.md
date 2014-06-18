ACT.TPMonitor
=============

TPMonitor for FFXIV on ACT

How to install
----------------
1.	ACT導入  
2.	FFXIV_ACT_Plugin.dll追加  
3.	Bin.zipをダウンロードし、展開  
4.	Advanced Combat Tracker.exeと同じフォルダに「FFXIV_ACT_Plugin.dll」と「ACT.TPMonitor.dll」を配置  
5.	Plugin -> Plugin Listingタブから4.「ACT.TPMonitor.dll」を選択  
6.	Add/Enable Pluginクリック  
7.	TPMonitorタブ選択  
8.	キャラフォルダー設定  

![Main](https://github.com/GB19xx/ACT.TPMonitor/blob/master/img/Settings.png "設定画面")


How to uninstall
----------------
1.	Plugin -> Plugin Listingタブから、[x]  
2.	配置したdll削除  
3.	設定ファイルの削除  
%AppData%\Roaming\Advanced Combat Tracker\Config\ACT.TPMonitor.config.xml  

Usage
------
/e TP [Command]  

Command  
・	/Show	：TPMonitor表示・再表示  

	下記をマクロにすると便利  
	/e TP 2:<2>  
	/e TP 3:<3>  
	/e TP 4:<4>  
	/e TP 5:<5>  
	/e TP 6:<6>  
	/e TP 7:<7>  
	/e TP 8:<8>  
	/e TP /Show  
・	/Hide	：TPMonitor非表示  

・	/Adjust	：位置調整  

Remarks
-----------
・	Win7(64bit)のみ動作確認  
・	マルチモニタ未検証  
・	サブキャラ未検証（フォルダ変えて）  
・	PTメンバーのイニシャル表示は未検証  
・	Widget Scale 100％のみ対応  
・	チャットの種別がないので、他人のコマンドにも反応  
・	CFはパーティ解散じゃないので手動で非表示に  

License
-------
三条項BSDライセンス (3-clause BSD license)

Special thanks
----------------
[pirulen](http://typodermicfonts.com/pirulen/)

