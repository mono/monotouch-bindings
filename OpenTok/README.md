OpenTok
=======

This binds the version `2.1.6` of the [OpenTok.Framework](https://github.com/opentok/opentok-ios-sdk-webrtc/tree/2.1.6)

All you need to do is run `make` and the `OpenTok.dll` will be inside the `binding` folder.

Once you have your resulting dll library, you can add that to a project.

As of version `2.1.6` You have to set 2 things in your project so OpenTok works.

1. Set Deployment Target to version `6.1` [see OpenTok Readme](https://github.com/opentok/opentok-ios-sdk-webrtc/blob/2.1.6/README.md#creating-your-own-app-using-the-opentok-20-ios-sdk) **you may have linking errors when you compile if you do not set this.**  ![Deployment](http://content.screencast.com/users/dalexsoto/folders/Jing/media/abe40cbb-b35b-4c60-8e8d-42d74b411aac/00000033.png)
2. Use the [Static Registrar](http://docs.xamarin.com/guides/ios/advanced_topics/registrar/) make sure you set the Additional mtouch arguments for every Device configuration you use (Debug, Release AppStore, etc.) ![Static Resgistrar](http://content.screencast.com/users/dalexsoto/folders/Jing/media/a91e859e-c011-465c-b9b0-6b227a166ab7/00000034.png)

Authors
=======
* Miguel de Icaza
* Alex Soto