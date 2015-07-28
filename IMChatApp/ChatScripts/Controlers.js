(function () {
    'use strict'
    app.controller("chatController", function ($scope, $rootScope, signalR, Flash) {
    $scope.$parent.UserName = "";
    $scope.rooms = [];// RoomFactory.Rooms;
    $scope.$parent.UserName = prompt("Enter unique name :");
    signalR.startHub();  
    $scope.activeRoom = '';
    $scope.chatHistory = [];
    $scope.Users = []
    $scope.RoomsLoggedId = [];     
    $scope.typemsgdisable = true;  
    signalR.UserEntered(function (room, user,cid) {
         if ($scope.activeRoom == room&&user!='') {          
            var result = $.grep($scope.users, function (e) { return e.name == user; })
            console.log("----------");           
            console.log(result);
            if (result != undefined || result != null) {
                $scope.users.push({ name: user, ConnectionId: cid });
                $scope.$apply();
            }
        }
    });
    signalR.UserLoggedOut(function (room, user) {
        if ($scope.activeRoom == room && user != '') {          
            $scope.users = $scope.users.filter(function (themObjects) {
                return themObjects.name != user;
            });          
               $scope.$apply();
            }        
    });

  //  Flash.add('success', message, 'custom-class')
    signalR.Login($scope.$parent.UserName);
    ///////////////// server
    
   
    $scope.UsersCount = 0;
    $scope.bubblesCount = [];
    $scope.maxBubbles = 10;
            
        $scope.ClosePrivateWindow = function ()
        {
            $scope.ShowPrivateWindow = false;
        }
   
        $scope.UserInPrivateChat = null;
        $scope.ShowPrivateWindow = false;
        $scope.PrivateMessages = [];
        $scope.currentprivatemessages = {};
        $scope.pvtmessage = '';
      $scope.OpenPrivatewindow = function (index) {
        debugger;
        var user = $scope.users[index];
      //  var conId = '#' + user.ConnectionId;
        $scope.ShowPrivateWindow = true;
        $scope.UserInPrivateChat = user;
        $scope.$apply();
       // $scope.createPrivateChatWindow($scope.$parent.UserName, conId, user.name)
      }
  
        $scope.SendPrivateMessage = function ()
        {
            //var user = $scope.users[index];
            //user.ConnectionId;
            // message // user id // connection id to send message  Message : to , from , msg
            debugger;
            signalR.SendPrivateMessage($scope.UserInPrivateChat.ConnectionId, $scope.pvtmessage);
            $scope.pvtmessage = '';
        }
        $scope.OnlineUsers = [];
        signalR.GetOnlineUsers(function (onlineUsers) {
            $scope.OnlineUsers = $.parseJSON(onlineUsers);
            console.log($scope.OnlineUsers);
            $scope.$apply();
        });
        signalR.NewOnlineUser(function (user) {
            $scope.OnlineUsers.push(user);
            $scope.$apply();
        });
        signalR.NewOfflineUser(function (user) {
            $.each($scope.OnlineUsers, function (i) {
                if ($scope.OnlineUsers[i].name === user.name && $scope.OnlineUsers[i].ConnectionId==user.ConnectionId) 
                    {
                    $scope.OnlineUsers.splice(i, 1);
                var message = '<strong> !!</strong>'+user.name +' left the chat ';
                debugger;
                Flash.create('success', message, 'custom-class');
                  
                   // Flash.add('success', user.name+ 'is logged off' , 'custom-class')
                    return false;
                }
            });
           // $scope.OnlineUsers.push(user);
            $scope.$apply();
        });
        
       // PrivateMessage($index)
        $scope.PrivateMessage = function (index) {
            debugger;
            var user = $scope.OnlineUsers[index];
            $scope.ShowPrivateWindow = true;
            $scope.UserInPrivateChat = user;
            console.log($scope.OnlineUsers);    +
            $scope.$apply();
        };
        signalR.RecievingPrivateMessage(function (toname,fromname, msg) {
           if ($scope.ShowPrivateWindow == false) {
                $scope.ShowPrivateWindow = true;
            }
           // var msgBdy = { room: r, msgx: { message: msg.message, sender: msg.sender, css: msg.css } };
            //$scope.chatHistory.push(msgBdy);
            $scope.PrivateMessages.push({ to: toname, from: fromname, message: msg });

            if ($scope.$parent.UserName != fromname) // otheruser's pm
            {
                if ($scope.UserInPrivateChat == null)
                {
                    $scope.UserInPrivateChat = { name: fromname, ConnectionId: toname }
                }
            }

            $scope.$evalAsync();
           // $scope.AddMessageToRoom(msgBdy);
        });
});

//////////////////////////////////////////////

function OpenPrivateChatWindow(chatHub, id, userName) {
    var ctrId = 'private_' + id;
    if ($('#' + ctrId).length > 0) return;
    createPrivateChatWindow(chatHub, id, ctrId, userName);

}
})();