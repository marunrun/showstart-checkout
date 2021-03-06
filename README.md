# showstart-checkout
秀动辅助下单，秀动抢票



github repo : https://github.com/marunrun/showstart-checkout

# 使用说明

### 一. 登陆
可使用验证码，密码登陆秀动账号。推荐密码登陆，使用密码登陆后，软件会默认记录下手机号和密码。请放心使用，账号密码只会保存在本地，不会上传云端。

使用工具登陆后，手机端账号会被顶掉，如需同时登陆您的账号，可以[登陆秀动网页版](https://wap.showstart.com)

同理，在手机端登陆账号后，需重新在本工具登陆。


### 二. 观影人与地址信息
使用本工具前，请登陆App 添加常用观影人（身份证信息）~~地址（实体票会需要您的地址）~~ 地址选择暂时不太好用，秀动更新之后没有找到需要选择地址的票，如果有出现实体票选择地址的演出，可以联系我  。 默认登陆后会拉取您的信息，如修改过信息，请点击刷新。


### 三. 演出搜索
默认根据演出名称搜索（同秀动APP的搜索），如通过名称无法在秀动搜索，可下拉选择“演出ID” ，输入演出ID进行搜索，演出ID如下：

`https://wap.showstart.com/pages/activity/detail/detail?activityId=133351`

其中：`acticityId=133351` `133351` 就是演出ID

### 四. 选票
当您进行演出搜索，并成功搜索到想要购票的演出时，选票会自动出现，并展示出剩余库存。

### 五. 优惠券
当您选票之后，会自动出现您当前选票可用的优惠券，并展示扣减的金额。（秀动更新后，我也没有可用的优惠券了，所以优惠券是否可用也未知）

### 六. 立即购票
顾名思义，点击立即购票会帮您购买当前选中的“选票”，~~如需滑动验证，会自动帮您滑块。~~ 

### 七. 开始捡漏
当您想要购买的票已经没有库存，但有乐迷未付款，或有人退票，或再次放票时，可使用本功能。本功能会帮您查看你当前选票的库存，一旦有多余库存，就会帮您下单，锁票。

### 八. 定时自动购票
请先选择时间，点击定时自动购票，本工具会定时帮您购票

# 特别说明
~~自动滑块验证使用[EdgeDriver](https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/) 可能在不同的电脑上不可用，请自行下载。~~

~~注意请勿频繁的滑块，会导致滑块失败。~~

滑块验证的现在已经不太好用了，建议大家使用密码登录，如果不放心密码的，可以在使用过后自行修改密码。



定时抢票的时间取的是演出对应的开票时间， 依赖于本机电脑时间，可以在 [time.is](http://time.is) 上查看本机时间于网络时间是否一致，如果不一致的话，建议自己同步一下网络时间。



建议不要开多个软件同时抢票，秀动下单是按照ip地址做了限流，短时间内频繁的下单会出现限流。



如果定时抢票失败，建议使用捡漏，作者已经使用捡漏模式捡到了很多票。

----

本软件免费使用，请勿轻信他人，不要花额外的钱去买票， livehouse本就越来越贵，希望每个人都能抢到原价票。

```diff
- 请勿使用本软件用于获利 本软件仅用于学习使用
```


暂时只支持window下使用，mac版本不知道何时更新，暂时没有计划。


如出现奇奇怪怪的bug，问题，欢迎反馈

如果觉得对你有用的话 也可以打赏一下

<img src="https://user-images.githubusercontent.com/35883111/179758068-b3d3d675-2471-4695-80df-7d24512ea760.jpg" width="400px">

