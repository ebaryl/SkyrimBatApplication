Scriptname AddItemMenuSEInitAlias extends ReferenceAlias  

bool once = true

MiscObject Property GiftObject Auto

Event OnInit()
	utility.wait(3)
	utility.wait(0.1)
	Actor player = Game.GetPlayer()
	if (GiftObject && player.GetItemCount(GiftObject) == 0)
		player.AddItem(GiftObject, 1)
	endif
	once = false
endEvent

Event OnPlayerLoadGame()
	if (once)
		OnInit()
	endif
endEvent
