all: AdJitsu.dll

libAdJitsuSDK.a:
	@echo "It would appear that you do not have a copy of libAdJitsu.a which"
	@echo "is needed to build the AdJitsu bindings."
	@echo
	@echo "You'll need to obtain a copy of libAdJitsuSDK.a from AdJitsu.com"
	@exit 1

AdJitsu.dll: Makefile AdJitsu.cs AssemblyInfo.cs libAdJitsuSDK.a
	/Developer/MonoTouch/usr/bin/btouch AdJitsu.cs AssemblyInfo.cs --link-with=libAdJitsuSDK.a,libAdJitsuSDK.a

clean:
	-rm -f *.dll
