<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Userid.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="js/jquery-ui-1.10.1.custom.min.js"></script>
    <script src="js/jquery-1.9.1.min.js"></script>
</head>
<body>

<video id="video" width="320" height="240" autoplay></video>
<canvas id="canvas" width="320" height="240"></canvas><br>
<p id="info"></p>
<button id="snap">拍照</button><button id="back" style="display:none" >返回</button>


<script>
    var aVideo = document.getElementById('video');
    var aCanvas = document.getElementById('canvas');
    var ctx = aCanvas.getContext('2d');

    navigator.getUserMedia = navigator.getUserMedia ||
        navigator.webkitGetUserMedia ||
        navigator.mozGetUserMedia ||
        navigator.msGetUserMedia;//获取媒体对象（这里指摄像头）
    navigator.getUserMedia({ video: true }, gotStream, noStream);//参数1获取用户打开权限；参数二成功打开后调用，并传一个视频流对象，参数三打开失败后调用，传错误信息

    function gotStream(stream) {
        video.src = URL.createObjectURL(stream);
        video.onerror = function () {
            stream.stop();
        };
        stream.onended = noStream;
        video.onloadedmetadata = function () {
            $("#info").html('请拍摄身份证正面！');
           
        };
    }
    function noStream(err) {
        alert(err);
    }

    document.getElementById("snap").addEventListener("click", function () {

        ctx.drawImage(aVideo, 0, 0, 320,240);//将获取视频绘制在画布上
        var base = aCanvas.toDataURL("image/png");        
        $("#video").hide();
        $("#snap").hide();
        $("#back").show();
        $("#canvas").show();
        $.post("checkid.aspx", { a: base }, function (data) { $("#info").html(data)});
    });
    $("#back").click(function () {

        $("#video").show();
        $("#snap").show();
        $("#back").hide();
        $("#canvas").hide();
        $("#info").html('请拍摄身份证正面！');
    })
</script>

</body>
</html>
