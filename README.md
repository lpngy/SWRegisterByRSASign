# SWRegisterByRSASign
利用C#实现的基于RSA签名方式的软件注册及验证工具

#文件目录说明
HardwareInfo：获取硬件信息的类，来自开源代码，包括各种获取机器信息的函数，有详细注释。

Key：放置了生成的私有密钥和公有密钥，注意：此密钥对要一起生成，要成对，不要经常生成，否则会混乱。用私钥进行签名，公钥发给用户用于验证。

lib：放置了一些第三方库，基本已经不使用。

RegisterCheck：用于验证注册是否有效的类。有详细注释。用于验证用的机器码可以由使用者个性化定义组合。

RegisterForBat：重要。开发者用的主要工具，包含了生成密钥（平时建议隐藏此按钮），生成注册码，保存注册码等。

RSA：RSA原理实现的主要类，勿动。

SecCommonTypes：一些公用类

testform：发给用户的注册机，用于生成自己的机器码，并验证测试是否注册成功。

# 软件注册流程
![注册流程](https://user-images.githubusercontent.com/28745945/160602571-66cd7812-dc7a-4997-8b4c-dafaab7adeee.png)

# 软件验证流程
![验证流程](https://user-images.githubusercontent.com/28745945/160602618-8cb80bed-6aed-48e2-bc01-061aee1cfc6d.png)
