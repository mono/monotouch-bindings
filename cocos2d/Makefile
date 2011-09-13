all: cocos2d.dll

cocos2d.dll: Makefile cocos2d.cs 
	/Developer/MonoTouch/usr/bin/btouch -d=MONOTOUCH -e cocos2d.cs enums.cs --sourceonly=list --tmpdir=ios
	/Developer/MonoTouch/usr/bin/smcs $(BUILD_FLAGS) -out:CorePlotiOS.dll -define:MONOTOUCH @list enums.cs extras.cs -r:monotouch.dll


clean: 
	-rm cocos2d.dll