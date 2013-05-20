# BPStatusBar

## Description

A utility class for displaying status updates in the iOS status bar.  Inspired by Mailbox and designed to function similar to SVProgressHUD.

## Screenshots

![Status Update](https://raw.github.com/brianpartridge/BPStatusBar/master/Screenshots/message.png "Status Update")
![Processing](https://raw.github.com/brianpartridge/BPStatusBar/master/Screenshots/spinner.png "Processing...")
![Task Success](https://raw.github.com/brianpartridge/BPStatusBar/master/Screenshots/success.png "Task Success")
![Task Failed](https://raw.github.com/brianpartridge/BPStatusBar/master/Screenshots/error.png "Task Failed")

## Usage

- Show a status

        [BPStatusBar showStatus:@"Something Happened"];
        
- Show a status with a spinner

        [BPStatusBar showActivityWithStatus:@"Working..."];

- Show a message with a success image and dismiss after 1 second

        [BPStatusBar showWithSuccess:@"Download Finished!"];
        
- See the included demo app for more.

## Known Limitations

- Rotation is not supported. Suggestions welcome.
- Works best with the UIStatusBarStyleBlackOpaque, using UIStatusBarStyleBlackTranslucent may not look right when the system statusbar reappears.
- No support for a determinate progress indicator.  This is replacing the system statusbar and ideally shouldn't be displayed for extended periods of time.

## License

MIT - See LICENSE.txt

## Thanks

Sam Vermentte - Much of SVProgressHUD's design is the basis for this project.

## Contact

[Brian Partridge](http://brianpartridge.name) - @brianpartridge on [Twitter](http://twitter.com/brianpartridge) and [App.Net](http://alpha.app.net/brianpartridge)