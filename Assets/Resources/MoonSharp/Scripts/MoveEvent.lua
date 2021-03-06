function main()
    sound.PlayBGM("title")
    fadePanel.PlayFadeIn()
    message.Wait(1)
    coroutine.yield()
    player.MoveTo("up", 3)
    coroutine.yield()
    player.Look("down")
    player.StopAnim()
    chocolate.Show(true)
    result = chocolate.JumpToPosition(-6, 0, true)
    message.ShowMessage("勇者「やったー！やったー！\n　　村人Jちゃんからチョコをもらった！")
    coroutine.yield()
    message.ShowMessage("勇者「ぼくはリア充だ！やったー！")
    select.Choose("ここで食べる", "後で食べる", "悩む", "なーむー")
    userInput = coroutine.yield(result)
    if userInput == 0 then
        message.ShowMessage("勇者「どんなチョコかな！\n　　すぐに食べちゃお！")
    elseif userInput == 1 then
        message.ShowMessage("勇者「やべ！こんな時間だ！\n　　スライム討伐のバイトがあったんだ！\n　　チョコは後で食べよう！")
    elseif userInput == 2 then
        message.ShowMessage("勇者「うーむ...")
    elseif userInput == 3 then
        message.ShowMessage("勇者「なーむーーーー")
    end
    coroutine.yield()
    chocolate.JumpToPosition(0, 14, true)
    coroutine.yield()
    message.ShowMessage("勇者「いそげ！いそげーーー！")
    coroutine.yield()
    player.MoveTo("down", 3)
    coroutine.yield()
    npcBoy.NormalSpeedPoint()
    coroutine.yield()

    sound.StopBGM()
    fadePanel.PlayFadeOut()
    coroutine.yield()
    message.ClearMessage()
    coroutine.yield()
    message.Wait(1)
    coroutine.yield()
    chocolate.Show(false)
    message.ShowMessage("1時間後...")
    coroutine.yield()
    player.Look("up")
    message.Wait(1)
    coroutine.yield()
    sound.PlayBGM("title")
    fadePanel.PlayFadeIn()
    coroutine.yield()
    message.ShowMessage("勇者「あー今日もスライム討伐がんばったぞー！")
    coroutine.yield()
    player.MoveTo("up", 3)
    coroutine.yield()
    message.ShowMessage("勇者「うぎゃーー！！！")
    player.StopAnim()
    coroutine.yield()
    message.ShowMessage("姫「ちょっと大きな声を出して\n　　どうしたの？")
    npcGirl.MoveTo("right", 6)
    coroutine.yield()
    npcGirl.StopAnim()
    message.ShowMessage("王「なんだ？なんだ？")
    npcBoy.Show(true)
    npcBoy.StopAnim()
    coroutine.yield()
    npcBoy.MoveTo("down", 4)
    coroutine.yield()
    npcBoy.MoveTo("left", 2)
    coroutine.yield()
    npcBoy.StopAnim()    
    player.Look("down")
    message.ShowMessage("勇者「ない！ないんだ！")
    coroutine.yield()
    message.ShowMessage("勇者「ないんだよ！！！\n　　ぼくのチョコが！！！")
    coroutine.yield()
    message.ShowMessage("姫「またぁー\n　　そもそももらってないんじゃないの？")
    coroutine.yield()
    message.ShowMessage("勇者「んなことないよ！\n　　バイト前にもらってここに置いといたんだから")
    coroutine.yield()
    message.ShowMessage("勇者「まさか！姫様が食べたんじゃないですよね？")
    coroutine.yield()
    message.ShowMessage("姫「そそそ...そんなわけないでしょ！\n　　チョコなんか友達からいっぱいもらってるし")
    coroutine.yield()
    message.ShowMessage("姫「証拠もないのに疑うのはやめてよね")
    coroutine.yield()
    message.ShowMessage("勇者「くやしい...くやしすぎるよ...\n　　もう寝る！！！ほっといてよ！！！")
    coroutine.yield()
    player.Look("right")
    player.MoveTo("right", 2)
    npcBoy.MoveTo("right", 2, false)
    coroutine.yield()
    player.Look("up")
    player.MoveTo("up", 2)
    coroutine.yield()
    player.Look("right")
    player.MoveTo("right", 4)
    coroutine.yield()
    player.Look("up")
    player.MoveTo("up", 4)
    coroutine.yield()
    message.ShowMessage("姫「なんだか かわいそうね...")
    coroutine.yield()
    message.ShowMessage("王「そ...そだね...あはは...")
    coroutine.yield()
    camera.JumpTo("up", 10)
    coroutine.yield()
    message.ShowMessage("勇者「くそぉーーー")
    coroutine.yield()
    message.ShowMessage("勇者「うえぇぇーーん")
    player.MoveTo("up", 4)
    coroutine.yield()
    player.Look("left")
    player.MoveTo("left", 10)
    coroutine.yield()
    player.Look("down")
    message.ShowMessage("勇者「寝てやる！寝てやるぞ！！\n　　グッスン...")
    coroutine.yield()
    player.StopAnim()
    message.ShowMessage("勇者「(この布団...\n　　甘い香りがするし少しあたたかいな...)")
    coroutine.yield()
    message.ShowMessage("勇者「(なんだか眠くなってきた...)")
    coroutine.yield()
    message.ShowMessage("勇者「...zzzZZZ")
    coroutine.yield()
    sound.StopBGM()
    message.ClearMessage()
    message.Wait(2)
    coroutine.yield()
    fadePanel.PlayFadeOut()
    coroutine.yield()
    message.Wait(4)
    coroutine.yield()
    message.ShowMessage("???「勇者よ...勇者よ...")
    coroutine.yield()
    message.ShowMessage("勇者「うん?なんだ?")
    coroutine.yield()
    message.ShowMessage("???「勇者よ...勇者よ... \n　　そなたに特別な時計を授けましょう")
    coroutine.yield()
    message.ShowMessage("???「この時計は時空を超えることができる\n　　時計です")
    coroutine.yield()
    message.ShowMessage("???「これを使って 魔王討伐に役立ててください")
    coroutine.yield()
    message.ShowMessage("勇者「なんだ？なんだってんだ...")
    coroutine.yield()
    message.ShowMessage("???「ただし 使えるのはたった1回のみ\n　　戻った過去に滞在できるのは1時間です")
    coroutine.yield()
    message.ShowMessage("???「有効に使うのですよ 魔王討伐は任せました")
    coroutine.yield()
    message.Wait(0.5)
    coroutine.yield()
    message.ClearMessage()
    coroutine.yield()
    fadePanel.PlayFadeIn()
    coroutine.yield()
    sound.PlayBGM("title")
    message.Wait(1)
    coroutine.yield()
    message.ShowMessage("勇者「...は！！夢か！！")
    coroutine.yield()
    message.ShowMessage("チャリン...")
    coroutine.yield()
    message.ShowMessage("勇者「なんだこれ?とけい?なのか?")
    coroutine.yield()
    message.ShowMessage("勇者「確か...魔王討伐にどうのこうの...")
    coroutine.yield()
    message.ShowMessage("勇者「あと 過去に戻れるっていってたな...")
    coroutine.yield()
    message.ShowMessage("勇者「過去...過去!???")
    coroutine.yield()
    message.ShowMessage("勇者「それじゃこれでチョコを盗んだ犯人が\n　　わかるじゃないか！")
    coroutine.yield()
    message.ShowMessage("勇者「よーし!こうなったら\n　　絶対犯人を見つけてやるぞ！")
    coroutine.yield()
    message.ShowMessage("勇者「使い方は...自分の戻りたい日時に\n　　タイマーをセットして...")
    coroutine.yield()
    message.ShowMessage("勇者「まてよ...戻れるのは1回だけで\n　　滞在時間は１時間だから")
    coroutine.yield()
    message.ShowMessage("勇者「ちょうどぼくがバイトにいく時間に\n　　セットすればいいか")
    coroutine.yield()
    message.ShowMessage("カチカチ")
    coroutine.yield()
    message.ShowMessage("勇者「よーし！これでスタートだ！！")
    coroutine.yield()
    message.ShowMessage("...")
    coroutine.yield()
    message.ShowMessage("...")
    coroutine.yield()
    message.ShowMessage("勇者「あれ?なにもおきない?")
    coroutine.yield()
    message.ShowMessage("...")
    coroutine.yield()
    message.ShowMessage("勇者「なんだよ...ウソかよ...\n　　 ウソつきかよ!!")
    coroutine.yield()
    message.ShowMessage("カチ...")
    coroutine.yield()
    message.ShowMessage("カチ...カチ...カチ...カチ!カチ!カチ!カチ!")
    coroutine.yield()
    message.ShowMessage("勇者「うわぁーーーなんだーーー！！？\n　　うわーー！！うわーー！！")
    coroutine.yield()
    sound.StopBGM()
    message.ClearMessage()
    fadePanel.PlayFadeOut()
    coroutine.yield()
    message.ClearMessage()
    coroutine.yield()
    message.Wait(4)
    coroutine.yield()
    fadePanel.PlayFadeIn()
    coroutine.yield()
    message.Wait(1)
    coroutine.yield()
    message.ShowMessage("勇者「...は！夢だったのか!?")
    coroutine.yield()
    message.ShowMessage("勇者「えっと...時間は...\n　　俺がちょうどバイトにいく時間じゃないか！")
    coroutine.yield()
    message.ShowMessage("勇者「ほんとに過去にもどれたんだ!!!!")
    coroutine.yield()
    message.ShowMessage("勇者「こうしてられない!\n　　早速チョコを見張って犯人を見つけないと!")
    coroutine.yield()
    sound.PlayBGM("title")
    message.ShowMessage("勇者「絶対 姫か王だよ!!")
    coroutine.yield()
    player.Look("right")
    player.MoveTo("right", 10)
    coroutine.yield()
    player.Look("down")
    player.MoveTo("down", 5)
    coroutine.yield()
    oldPlayer.Show(true)
    npcGirl.JumpToPosition(-7,0)
    npcBoy.JumpToPosition(0,-4)
    npcBoy.Show(true)
    chocolate.Show(true)
    chocolate.JumpToPosition(-6, 0, true)
    message.Wait(0.5)
    coroutine.yield()
    camera.JumpTo("down", 10)
    coroutine.yield()
    message.ShowMessage("勇者「(おっと...ぼくがまだいる...)")
    coroutine.yield()
    message.ShowMessage("過去勇者「やったー！やったー！\n　　村人Jちゃんからチョコをもらった！")
    coroutine.yield()
    message.ShowMessage("過去勇者「ぼくはリア充だ！やったー！")
    coroutine.yield()
    message.ShowMessage("過去勇者「やべ！こんな時間だ！\n　　スライム討伐のバイトがあったんだ！\n　　チョコは後で食べよう！")
    chocolate.JumpToPosition(0, 14, true)
    coroutine.yield()
    message.ShowMessage("過去勇者「いそげ！いそげーーー！")
    coroutine.yield()
    oldPlayer.MoveTo("down", 4)
    coroutine.yield()
    message.ShowMessage("勇者「(はたからみてると あの独り言って\n　　 すごく痛いやつだな)")
    coroutine.yield()
    message.ShowMessage("勇者「なこと考えてる場合じゃなかった.\n　　このまま隠れて見張っておこう.")
    coroutine.yield()
    message.Wait(0.5)
    coroutine.yield()

    message.ShowMessage("カッチ...カッチ...カッチ...")
    coroutine.yield()
    message.ShowMessage("カッチ...カッチ...カッチ...")
    coroutine.yield()
    message.ShowMessage("勇者「15分たっても誰もこないなぁ...")
    coroutine.yield()
    message.ShowMessage("???「あーあ...今日も疲れたー")
    coroutine.yield()
    message.ShowMessage("勇者「(お！..誰かくるぞ...)")
    coroutine.yield()
    npcGirl.MoveTo("right",7)
    message.ShowMessage("姫「もーほんとにやんなちゃうよー\n　　在宅なのにスライム倒せって")
    coroutine.yield()
    message.ShowMessage("姫「パワハラもいいとこじゃない")
    coroutine.yield()
    npcGirl.Look("up")
    message.ShowMessage("姫「あ！何これチョコレートあんじゃん\n　　ラッキーあけちゃお！")
    coroutine.yield()
    message.ShowMessage("(パカッ)")
    coroutine.yield()
    message.ShowMessage("勇者「(姫！！やっぱあいつだったのか！！\n　　こうなったら懲らしめてやる！)")
    coroutine.yield()
    message.ShowMessage("姫「うん?でもこれ...手作りだね...\n　　私そうゆうの苦手だからなぁ...")
    coroutine.yield()
    message.ShowMessage("姫「執事に頼んで職人が作ったやつをもらおーっと")
    coroutine.yield()
    message.ShowMessage("姫「執事 執事ー")
    coroutine.yield()
    npcGirl.MoveTo("left",7)
    coroutine.yield()
    message.Wait(1)
    player.MoveTo("down",4)
    coroutine.yield()
    player.MoveTo("left",4)
    coroutine.yield()
    player.MoveTo("down",1)
    coroutine.yield()
    player.MoveTo("left",2)
    coroutine.yield()
    player.Look("up")
    message.ShowMessage("勇者「たしかに ある あれー姫じゃなかったのか")
    coroutine.yield()
    message.ShowMessage("勇者「じゃあ いったい誰なんだろう...\n　　やべ誰か来る!")
    coroutine.yield()
    player.MoveTo("right",2)
    coroutine.yield()
    player.MoveTo("up",1)
    coroutine.yield()
    player.MoveTo("right",4)
    coroutine.yield()
    player.MoveTo("up",4)
    coroutine.yield()
    player.Look("down")
    message.Wait(0.5)
    coroutine.yield()
    npcBoy.JumpToPosition(0,-4)
    npcBoy.Show(true)
    coroutine.yield()
    message.ShowMessage("王「あーあー今日も疲れたなぁ\n　　書類にハンコばっかり")
    coroutine.yield()
    npcBoy.MoveTo("up",4)
    message.ShowMessage("王「スライムの討伐指示出しても誰もやらないし\n　　困った家臣ばっかりだ")
    coroutine.yield()
    message.ShowMessage("王「お！チョコあるじゃん")
    coroutine.yield()
    message.ShowMessage("(パカッ)")
    coroutine.yield()
    message.ShowMessage("勇者「(王！！まさかあなたなのか！！\n　　あなたなんですね！！)")
    coroutine.yield()
    message.ShowMessage("王「うーむ でも盗みはよくないね\n　　つぼの中身を盗む勇者じゃあるまいし")
    coroutine.yield()
    message.ShowMessage("王「早く布団で寝よーっと")
    coroutine.yield()
    npcBoy.MoveTo("right",3)
    coroutine.yield()
    npcBoy.MoveTo("up",4)
    coroutine.yield()
    message.Wait(0.5)
    coroutine.yield()
    npcBoy.Show(false)
    coroutine.yield()
    message.Wait(1)
    player.MoveTo("down",4)
    coroutine.yield()
    player.MoveTo("left",4)
    coroutine.yield()
    player.MoveTo("down",1)
    coroutine.yield()
    player.MoveTo("left",2)
    coroutine.yield()
    player.Look("up")
    message.ShowMessage("勇者「なんか色々引っかかるけど\n　　確かにある...")
    coroutine.yield()
    message.ShowMessage("勇者「2人じゃないとすると いったい\n　　だれなんだろうか...")
    coroutine.yield()
    message.ShowMessage("勇者「とりあえず しばらくみはっておこう")
    coroutine.yield()
    player.MoveTo("right",2)
    coroutine.yield()
    player.MoveTo("up",1)
    coroutine.yield()
    player.MoveTo("right",4)
    coroutine.yield()
    player.MoveTo("up",4)
    coroutine.yield()
    player.Look("down")
    message.Wait(0.5)
    coroutine.yield()

    message.ShowMessage("カッチ...カッチ...カッチ...")
    coroutine.yield()
    message.ShowMessage("カッチ...カッチ...カッチ...")
    coroutine.yield()
    fadePanel.PlayFadeOut()
    coroutine.yield()
    message.Wait(0.5)
    coroutine.yield()
    message.ShowMessage("カッチ...カッチ...カッチ...")
    coroutine.yield()
    message.ShowMessage("のこり滞在可能時間 5分")
    coroutine.yield()
    fadePanel.PlayFadeIn()
    coroutine.yield()
    message.Wait(0.5)
    message.ShowMessage("勇者「あーもう時間がない!")
    coroutine.yield()
    player.MoveTo("down",4)
    coroutine.yield()
    player.MoveTo("left",4)
    coroutine.yield()
    player.MoveTo("down",1)
    coroutine.yield()
    player.MoveTo("left",2)
    coroutine.yield()
    player.Look("down")
    message.ShowMessage("勇者「この世界にいられるのはあと数分...\n　　しかも この時計は1回しか使えない.")
    coroutine.yield()
    message.ShowMessage("勇者「ぼくが このチョコを食べれる\n　　世界はこないってことか...")
    coroutine.yield()
    message.ShowMessage("勇者「くやしいなぁ 村人Jちゃんの手作りチョコ\n　　食べたかったなぁ...")
    coroutine.yield()
    message.ShowMessage("カッチ...カッチ...カッチ...")
    coroutine.yield()
    message.ShowMessage("勇者「まてよ...ここにあるじゃないか！")
    coroutine.yield()
    chocolate.Show(true)
    chocolate.JumpToPosition(-6, 0, true)
    message.ShowMessage("カッチ...カッチ...カッチ...")
    coroutine.yield()
    message.ShowMessage("勇者「時間がない...\n　　どうしよう食べちゃおうか...")
    coroutine.yield()
    chocolate.Show(false)
    player.MoveTo("left",1)
    coroutine.yield()
    player.MoveTo("right",1)
    coroutine.yield()
    player.MoveTo("left",1)
    coroutine.yield()
    player.MoveTo("right",1)
    coroutine.yield()
    message.ShowMessage("過去勇者「あー今日もスライム討伐がんばったぞー！")
    coroutine.yield()
    message.ShowMessage("勇者「(やべ！ぼくが帰ってくる 隠れないと)")
    coroutine.yield()
    player.MoveTo("right", 2)
    coroutine.yield()
    player.MoveTo("up", 2)
    coroutine.yield()
    player.MoveTo("right", 4)
    coroutine.yield()
    player.MoveTo("up", 3)
    coroutine.yield()
    camera.JumpTo("up", 10)
    coroutine.yield()
    player.MoveTo("up", 5)
    coroutine.yield()
    player.MoveTo("left", 10)
    coroutine.yield()
    player.Look("down")
    chocolate.Show(true)
    chocolate.JumpToPosition(-45, 100, true)

    message.ShowMessage("過去勇者「うぎゃーー！！！")
    coroutine.yield()
    message.ShowMessage("カチ...")
    coroutine.yield()
    message.ShowMessage("勇者「もう時間がない...\n　　こうなったら食べちゃえ！！！")
    coroutine.yield()
    message.ShowMessage("勇者「(パクッ!)おいしぃ...おいしぃよ...")
    coroutine.yield()
    message.ShowMessage("勇者「(パクッ!)これが手作りチョコの味かぁ")
    coroutine.yield()
    message.ShowMessage("カチ...カチ...カチ...カチ!カチ!カチ!カチ!")
    coroutine.yield()
    message.ShowMessage("勇者「そろそろ時間か...\n　　うわぁーーー！\n　　うわーー！！うわーー！！")
    coroutine.yield()
    sound.StopBGM()
    fadePanel.PlayFadeOut()
    message.Wait(2)
    coroutine.yield()
    message.Wait(2)
    message.ClearMessage()
    fadePanel.PlayFadeIn()
    coroutine.yield()
    message.Wait(2)
    coroutine.yield()
    chocolate.Show(true)
    chocolate.JumpToPosition(-45, 100, true)
    message.ShowMessage("勇者「...は！戻ってきたのか！？")
    coroutine.yield()
    message.ShowMessage("勇者「ふぅ...危なかった \n　　もう少しでチョコが食べれないとこだった")
    coroutine.yield()
    message.ShowMessage("勇者「でも...\n　　犯人はいなかったわけだし")
    coroutine.yield()
    message.ShowMessage("勇者「いったいだれが \n　　このチョコを食べたんたんだろう...")
    coroutine.yield()
    fadePanel.PlayFadeOut()
    coroutine.yield()
    message.Wait(2)
    coroutine.yield()
    message.ShowMessage("おしまい")
    coroutine.yield()
    message.Wait(4)
    coroutine.yield()
    sound.PlayBGM("title")
    message.ShowMessage("っとまぁ...\n世の中には知らず知らずのうちに\nなくなっているものがあったりします")
    coroutine.yield()
    message.ShowMessage("それはもしかすると...\nあなたのせいだったりするかもしれませんね")
    coroutine.yield()
    message.ShowMessage("スタジオしまづ事件簿\nカチカチ時計と消えたチョコレート\nお楽しみいただけましたでしょうか")
    coroutine.yield()
    message.ShowMessage("それではまた...どこかの世界で...")
    coroutine.yield()
end