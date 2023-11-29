# 端口映射工具

该项目是我首次参加工作期间编写的，提供给第三方使用。
This project was written by me during my first participation in work and provided to third parties.

[![](https://img.alicdn.com/imgextra/i4/232721121/TB2_GL2lhBmpuFjSZFsXXcXpFXa_!!232721121.png)](https://github.com/strongQ/portMapper)

# 使用场景 

该软件在以下场合适用：

1. 需要隐藏真正TCP服务器的位置。

2. 限制客户端IP登陆

3. TCP转地址

This software is suitable for the following situations:

1. The location of the real TCP server needs to be hidden.

2. Restrict client IP login

3. TCP address transfer

# 实现原理

1. 根据输入ip和端口创建socket服务监听客户端。

2. 当新客户端连进来后，创建新的socket对象，连接到输出ip和端口创建的服务器上。

3. 交换两个socket对象的数据。

Method

1. Create a socket service listening client based on the input IP and port.

2. When a new client connects, create a new socket object and connect to the server created with the output IP and port.

3. Exchange data between two socket objects.
