## Summary

本文档是农场综合管理系统的rest接口文档。提供了所有可用接口的概览及详细信息。主要为公司内部前台（web、client、mobile）开发提供数据接口。

## Api List

[**Docs**](#docs)

| 接口描述 | 请求方式 | 请求地址              |
| -------- | -------- | --------------------- |
| [接口文档](#getdocs) | GET      | /api/v1/docs |

[**Dics**](#dics)

| 接口描述 | 请求方式 | 请求地址              |
| -------- | -------- | --------------------- |
| [获取字典表](#getdics) | GET      | /api/v1/dics |

[**Auth**](#auth)

| 接口描述 | 请求方式 | 请求地址              |
| -------- | -------- | --------------------- |
| [访问授权](#getauth) | GET      | /api/v1/auth |

[**Users**](#users)

| 接口描述     | 请求方式 | 请求地址                     |
| ------------ | -------- | ---------------------------- |
| [获取用户信息](#getuserbyid) | GET      | /api/v1/users?id=id |
| [修改用户信息](#putuser) | PUT      | /api/v1/users       |

[**Farms**](#farms)

| 接口描述     | 请求方式 | 请求地址                      |
| ------------ | -------- | ----------------------------- |
| [创建农场](#postfarm) | POST      | /api/v1/farms  |
| [获取农场信息](#getfarmbyid) | GET      | /api/v1/farms?id=id |
| [获取区域农场列表](#getfarmbyaddress) | GET      | /api/v1/farms?prov=prov&city=city&county=county |
| [修改农场信息](#putfarm) | PUT      | /api/v1/farms |

[**Fields**](#fields)

| 接口描述 | 请求方式 | 请求地址               |
| -------- | -------- | ---------------------- |
| [新增地块](#postfield) | PSOT     | /api/v1/fields |
| [获取地块信息](#getfieldbyid) | GET | /api/v1/fields?id=id |
| [获取农场所有地块](#getfieldbyfarmid) | GET | /api/v1/fields?farm_id=farm_id |
| [修改地块](#putfield) | PUT     | /api/v1/fields |
| [删除地块](#deletefieldbyid) | DELETE     | /api/v1/fields?id=id |

[**Tasks**](#tasks)

| 接口描述     | 请求方式 | 请求地址                      |
| ------------ | -------- | ----------------------------- |
| [创建任务](#posttask) | POST      | /api/v1/tasks  |
| [获取用户发送的任务](#gettaskbysenderid) | GET      | /api/v1/tasks?sender_id=sender_id&limit=limit&offset=offset |
| [获取用户接收的任务](#gettaskbyreceiverid) | GET      | /api/v1/tasks?receiver_id=receiver_id&limit=limit&offset=offset |
| [修改任务信息](#puttask) | PUT      | /api/v1/tasks |

[**RSIs**](#rsis)

| 接口描述 | 请求方式 | 请求地址              |
| -------- | -------- | --------------------- |
| [获取农情信息](#getrsibyfarmid) | GET      | /api/v1/rsis?farm_id=farm_id |

[**FieldLives**](#fieldlives)

| 接口描述 | 请求方式 | 请求地址              |
| -------- | -------- | --------------------- |
| [提交地块实况信息](#postfieldlive) | POST      | /api/v1/fieldlives |
| [获取地块实况信息](#getfieldlivebyfarmid)| GET      | /api/v1/fieldlives?farm_id=farm_id&start=start&end=end |

[**News**](#news)

| 接口描述 | 请求方式 | 请求地址              |
| -------- | -------- | --------------------- |
| [获取新闻资讯](#getnewsbytype) | GET      | /api/v1/news?type=type&limit=limit&offset=offset |

[**FeedBacks**](#feedbacks)

| 接口描述 | 请求方式 | 请求地址              |
| -------- | -------- | --------------------- |
| [提交意见反馈](#postfeedback) | POST      | /api/v1/feedbacks |

## Response

**返回值结构**

```
{
    status : 响应状态
    msg : 消息
    data : 返回数据
}
```

**消息列表**

```
SUCCEED = "succeed";
NOT_AUTH = "未授权";
AUTH_ERROR = "授权错误";
UNKNOWN_ERROR = "未知错误";
SERVER_ERROR = "服务器错误";
INVALID_MOBILE = "无效的手机号码";
DATA_NOT_FOUND = "请求的数据不存在";
```

## Docs

### GetDocs

**访问地址**

```
/api/v1/docs
```

**接口描述**

获取和查阅接口文档。

**请求参数**

无。

**请求头**

无。

**请求体**

无。

**返回值**

html页面

## Dics

### GetDics

**访问地址**

```
 /api/v1/dics
```

**接口描述**

获取所有字典信息。

**请求参数**

无。

**请求头**

无。

**请求体**

无。

**返回值**

返回所有字典列表，包括：
- dic_crop : 作物类型
- dic_disease : 病害类型
- dic_growth : 长势类型
- dic_moisture : 土壤湿度类型
- dic_news : 新闻类型
- dic_pest : 虫害类型
- dic_rsi : 农情数据类型
- dic_phenophase : 物候期类型

*响应示例*

```
{
    status : true
    msg : succeed
    data : {
        "dic_crop": [
            {"id":1,"crop_type":"冬小麦"},
            ...
            ]
        "dic_disease": [
            {"id":1,"disease_type":"白粉病"},
            ...
            ]
        "dic_growth": [
            {"id":1,"growth_type":"好"},
            ...
            ]
        "dic_moisture": [
            {"id":1,"moisture_type":"干旱"},
            ...
            ]
        "dic_news": [
            {"id":1,"news_type":"置顶新闻"},
            ...
            ]
        "dic_pest": [
            {"id":1,"pest_type":"蚜虫"},
            ...
            ]
        "dic_rsi": [
            {"id":1,"rsi_type":"长势"},
            ...
            ]
        "dic_phenophase": [
            {"id":1,"crop_id":1,"type":"播种期","days":"1","detail":"***"},
            ...
            ]
    }
}
```

## Auth

### GetAuth

**访问地址**

```
 /api/v1/auth?mobile=mobile
```

**接口描述**

用户访问授权。

**请求参数**

```
mobile：手机号
```

**请求头**

无。

**请求体**

无。

**返回值**

返回授权码和用户对象。

*响应示例*

```
{
  "status": true,
  "msg": "succeed",
  "data": {
    "token": "0KOQX0hqCiXTBMKghQDFAOBP0SBHDUvYzI/IsYKCXns=",
    "user": {
      "id": 5,
      "name": "12345678910",
      "mobile": "12345678910",
      "farm_id": -1,
      "thumb_url": ""
    }
  }
}
```

## Users

### GetUserById

**访问地址**

```
 /api/v1/users?id=id
```

**接口描述**

获取用户信息。

**请求参数**

```
id：用户编号
```

**请求头**

必须包含以下字段
```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回用户信息。

```
{
    "status":true,
    "msg":"succeed",
    "data":{
        "id":用户编号,
        "name":"用户名",
        "mobile":"手机号",
        "farm_id":所属农场编号，无农场-1,
        "thumb_url":"头像地址"
        }
}
```

### PutUser

**访问地址**

```
 /api/v1/users
```

**接口描述**

修改用户信息。

**请求参数**

无。

**请求头**

必须包含以下字段

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

user对象，必须包含正确的id。

*示例*

```
{
        "id":用户编号,
        "name":"用户名",
        "mobile":"手机号",
        "farm_id":所属农场编号，无农场-1,
        "thumb_url":"头像地址"
}
```

**返回值**

返回更新后的用户信息。

*响应示例*

```
{
    "status":true,
    "msg":"succeed",
    "data":{
        "id":用户编号,
        "name":"用户名",
        "mobile":"手机号",
        "farm_id":所属农场编号，无农场-1,
        "thumb_url":"头像地址"
        }
}
```

## Farms

### PostFarm

**访问地址**

```
 api/v1/farms
```

**接口描述**

创建农场。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

farm对象。

*示例：*

```
{
    "id":-1,
    "name":"15066393930",
    "owner":3,
    "province":"北京",
    "city":"北京",
    "county":"西城区",
    "street":"新街口外大街8号院"
}
```

**返回值**

返回新增农场的完整信息。

*响应示例*

```
{
    "status":true,
    "msg":"succeed",
    "data":{
        "id":1,
        "name":"15066393930",
        "owner":3,
        "province":"北京",
        "city":"北京",
        "county":"西城区",
        "street":"新街口外大街8号院"
        }
}
```

### GetFarmById

**访问地址**

```
 api/v1/farms?id=id
```

**接口描述**

获取指定农场信息。

**请求参数**

```
    id:农场编号
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回农场信息。

*响应示例*

```
{
    "status":true,
    "msg":"succeed",
    "data":{
        "id":1,
        "name":"15066393930",
        "owner":3,
        "province":"北京",
        "city":"北京",
        "county":"西城区",
        "street":"新街口外大街8号院"
        }
}
```

### GetFarmByAddress

**访问地址**

```
 api/v1/farms?prov=prov&city=city&county=county
```

**接口描述**

获取某县的所有农场信息。

**请求参数**

```
    prov:省份
    city:城市
    county:区县
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回农场信息。

*响应示例*

```
{
  "status": true,
  "msg": "succeed",
  "data": [
    {
      "id": 1,
      "name": "17343003930",
      "owner": 2,
      "province": "北京",
      "city": "北京",
      "county": "西城区",
      "street": "新街口外大街8号院"
    },
    {
      "id": 2,
      "name": "15066393930",
      "owner": 3,
      "province": "北京",
      "city": "北京",
      "county": "西城区",
      "street": "新街口外大街8号院"
    }
  ]
}
```

### PutFarm

**访问地址**

```
 api/v1/farms
```

**接口描述**

修改农场信息。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

farm对象。

*示例：*

```
{
    "id":1,
    "name":"15066393930",
    "owner":3,
    "province":"北京",
    "city":"北京",
    "county":"西城区",
    "street":"新街口外大街8号院"
}
```

**返回值**

返回更新后的农场信息。

*响应示例*

```
{
    "status":true,
    "msg":"succeed",
    "data":{
        "id":1,
        "name":"15066393930",
        "owner":3,
        "province":"北京",
        "city":"北京",
        "county":"西城区",
        "street":"新街口外大街8号院"
        }
}
```

## Fields

### PostField

**访问地址**

```
 api/v1/fields
```

**接口描述**

新建地块。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

field对象。

*示例：*

```
{
    "id": 2,
    "name": "17343003930",
    "area": 100,
    "create_date": "2018-08-24T00:00:00",
    "thumb_url": "",
    "geom": [
      [
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83592083345695,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83433021779223,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83480310686135,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        }
      ]
    ],
    "farm_id": 1,
    "crop_id": 1,
    "sow_date": "2018-08-24T00:00:00",
    "phenophase": 1
  }
```

**返回值**

返回新增的地块信息。

*响应示例*

```
{
  "status": false,
  "msg": "succeed",
  "data": {
    "id": 2,
    "name": "17343003930",
    "area": 100,
    "create_date": "2018-08-24T00:00:00",
    "thumb_url": "",
    "geom": [
      [
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83592083345695,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83433021779223,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83480310686135,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        }
      ]
    ],
    "farm_id": 1,
    "crop_id": 1,
    "sow_date": "2018-08-24T00:00:00",
    "phenophase": 1
  }
}
```

### GetFieldById

**访问地址**

```
 api/v1/fields?id=id
```

**接口描述**

获取指定地块信息。

**请求参数**

```
id : 地块编号
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回请求的地块信息。

*响应示例*

```
{
  "status": false,
  "msg": "succeed",
  "data": {
    "id": 2,
    "name": "17343003930",
    "area": 100,
    "create_date": "2018-08-24T00:00:00",
    "thumb_url": "",
    "geom": [
      [
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83592083345695,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83433021779223,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83480310686135,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        }
      ]
    ],
    "farm_id": 1,
    "crop_id": 1,
    "sow_date": "2018-08-24T00:00:00",
    "phenophase": 1
  }
}
```

### GetFieldByFarmId

**访问地址**

```
 api/v1/fields/farm_id=farm_id
```

**接口描述**

获取指定农场的所有地块信息。

**请求参数**

```
farm_id : 农场编号
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回农场的所有地块。

*响应示例*

```
{
  "status": true,
  "msg": "succeed",
  "data": [
    {
      "id": 3,
      "name": "17343003930",
      "area": 100,
      "create_date": "2018-08-24T00:00:00",
      "thumb_url": "",
      "geom": [
        [
          {
            "X": 35.83580046365707,
            "Y": 116.85497244195284
          },
          {
            "X": 35.83592083345695,
            "Y": 116.86055092850006
          },
          {
            "X": 35.83433021779223,
            "Y": 116.86055092850006
          },
          {
            "X": 35.83480310686135,
            "Y": 116.85497244195284
          },
          {
            "X": 35.83580046365707,
            "Y": 116.85497244195284
          }
        ]
      ],
      "farm_id": 2,
      "crop_id": 1,
      "sow_date": "2018-08-24T00:00:00",
      "phenophase": 1
    }
  ]
}
```

### PutField

**访问地址**

```
 api/v1/fields
```

**接口描述**

修改地块信息。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

field对象。

*示例：*

```
{
    "id": 2,
    "name": "17343003930",
    "area": 100,
    "create_date": "2018-08-24T00:00:00",
    "thumb_url": "",
    "geom": [
      [
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83592083345695,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83433021779223,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83480310686135,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        }
      ]
    ],
    "farm_id": 1,
    "crop_id": 1,
    "sow_date": "2018-08-24T00:00:00",
    "phenophase": 1
  }
```

**返回值**

更新后的地块完整信息。

*响应示例*

```
{
  "status": false,
  "msg": "succeed",
  "data": {
    "id": 2,
    "name": "17343003930",
    "area": 100,
    "create_date": "2018-08-24T00:00:00",
    "thumb_url": "",
    "geom": [
      [
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83592083345695,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83433021779223,
          "Y": 116.86055092850006
        },
        {
          "X": 35.83480310686135,
          "Y": 116.85497244195284
        },
        {
          "X": 35.83580046365707,
          "Y": 116.85497244195284
        }
      ]
    ],
    "farm_id": 1,
    "crop_id": 1,
    "sow_date": "2018-08-24T00:00:00",
    "phenophase": 1
  }
}
```

### DeleteFieldById

**访问地址**

```
 api/v1/fields?id=id
```

**接口描述**

删除指定地块。

**请求参数**

```
id : 地块编号
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

是否删除成功。

*响应示例*

```
{
  "status": false,
  "msg": "succeed",
  "data": null   
}
```

## Tasks

### PostTask

**访问地址**

```
 api/v1/tasks
```

**接口描述**

创建申请。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

task对象。

*示例：*

```
{
  "id": 0,
  "farm_id": 1,
  "sender_id": 1,
  "receiver_id": 2,
  "type_id": 0,
  "desc": "手机号为17343003930的用户申请加入你的农场",
  "state": false,
  "agree": false,
  "create_date": "2018-08-27T00:00:00",
  "process_date": "2000-01-01T00:00:00"
}
```

**返回值**

返回新增task的完整信息。

*响应示例*

```
{
    "status": true,
    "msg": "succeed",
    "data": {
        "id": 2,
        "farm_id": 1,
        "sender_id": 1,
        "receiver_id": 2,
        "type_id": 0,
        "desc": "手机号为17343003930的用户申请加入你的农场",
        "state": false,
        "agree": false,
        "create_date": "2018-08-27T00:00:00",
        "process_date": "2000-01-01T00:00:00"
    }
}
```

### GetTaskBySenderId

**访问地址**

```
 api/v1/tasks?sender_id=sender_id&limit=limit&offset=offset
```

**接口描述**

获取用户发送的任务消息。

**请求参数**

```
sender_id：用户编号

limit：获取个数

offset：起始位置
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回用户发送的消息。

*响应示例*

```
{
    "status": true,
    "msg": "succeed",
    "data": [
        {
            "id": 1,
            "farm_id": 1,
            "sender_id": 1,
            "receiver_id": 2,
            "type_id": 0,
            "desc": "手机号为17343003930的用户申请加入你的农场",
            "state": false,
            "agree": false,
            "create_date": "2000-01-01T00:00:00",
            "process_date": "2000-01-01T00:00:00"
        },
        {
            "id": 2,
            "farm_id": 1,
            "sender_id": 1,
            "receiver_id": 2,
            "type_id": 0,
            "desc": "手机号为17343003930的用户申请加入你的农场",
            "state": false,
            "agree": false,
            "create_date": "2018-08-27T00:00:00",
            "process_date": "2000-01-01T00:00:00"
        }
    ]
}
```

### GetTaskByReceiverId

**访问地址**

```
 api/v1/tasks?receiver_id=receiver_id&limit=limit&offset=offset
```

**接口描述**

获取用户接收的任务消息。

**请求参数**

```
receiver_id：用户编号

limit：获取个数

offset：起始位置
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回用户接收的消息。

*响应示例*

```
{
    "status": true,
    "msg": "succeed",
    "data": [
        {
            "id": 1,
            "farm_id": 1,
            "sender_id": 1,
            "receiver_id": 2,
            "type_id": 0,
            "desc": "手机号为17343003930的用户申请加入你的农场",
            "state": false,
            "agree": false,
            "create_date": "2000-01-01T00:00:00",
            "process_date": "2000-01-01T00:00:00"
        },
        {
            "id": 2,
            "farm_id": 1,
            "sender_id": 1,
            "receiver_id": 2,
            "type_id": 0,
            "desc": "手机号为17343003930的用户申请加入你的农场",
            "state": false,
            "agree": false,
            "create_date": "2018-08-27T00:00:00",
            "process_date": "2000-01-01T00:00:00"
        }
    ]
}
```

### PutTask

**访问地址**

```
 api/v1/tasks
```

**接口描述**

修改任务消息。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

task对象。

*示例：*

```
{
  "id": 0,
  "farm_id": 1,
  "sender_id": 1,
  "receiver_id": 2,
  "type_id": 0,
  "desc": "手机号为17343003930的用户申请加入你的农场",
  "state": false,
  "agree": false,
  "create_date": "2018-08-27T00:00:00",
  "process_date": "2000-01-01T00:00:00"
}
```

**返回值**

返回修改后的任务完整消息。

*响应示例*

```
{
    "status": true,
    "msg": "succeed",
    "data": {
        "id": 2,
        "farm_id": 1,
        "sender_id": 1,
        "receiver_id": 2,
        "type_id": 0,
        "desc": "手机号为17343003930的用户申请加入你的农场",
        "state": false,
        "agree": false,
        "create_date": "2018-08-27T00:00:00",
        "process_date": "2000-01-01T00:00:00"
    }
}
```

## RSIs

### GetRSIByFarmId

**访问地址**

```
 api/v1/rsis?farm_id=farm_id
```

**接口描述**

获取指定农场最新农情监测数据。

**请求参数**

```
farm_id：农场编号
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回所有地块，所有类别的最新农情数据列表。

*响应示例*

```
{
	"status": true,
	"msg": "succeed",
	"data": [{
		"id": 2,
		"farm_id": 1,
		"field_id": 2,
		"type_id": 2,
		"product_date": "2018-08-27T00:00:00",
		"update_date": "2018-08-27T00:00:00",
		"grade_id": 2,
		"value": "0.8"
	}, {
		"id": 1,
		"farm_id": 1,
		"field_id": 3,
		"type_id": 1,
		"product_date": "2018-08-27T00:00:00",
		"update_date": "2018-08-27T00:00:00",
		"grade_id": 1,
		"value": "0.5"
	}]
}
```

## FieldLives

### PostFieldLive

**访问地址**

```
 api/v1/fieldlives
```

**接口描述**

提交地块实况信息。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

FieldLive对象。

*请求示例*

```
{
    "id": 3,
    "farm_id": 1,
    "field_id": 1,
    "growth_id": 1,
    "moisture_id": 1,
    "disease_id": 1,
    "pest_id": 1,
    "collector": 1,
    "collect_date": "2018-08-28T00:00:00",
    "gps": {
      "X": 36.546,
      "Y": 114.125,
      "SRID": 4326
    },
    "picture": "\img\17343003930\*.jpg"
  }
```

**返回值**

返回执行状态。

*响应示例*

```
{
	"status": true,
	"msg": "succeed",
	"data": null
}
```

### GetFieldLiveByFarmId

**访问地址**

```
 api/v1/fieldlives?farm_id=farm_id&start=start&end=end
```

**接口描述**

获取指定农场的地块实况信息。

**请求参数**

```
farm_id：农场编号

start：开始时间

end：结束时间
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

返回地块实况列表。

*响应示例*

```
{
  "status": true,
  "msg": "succeed",
  "data": [{
    "id": 1,
    "farm_id": -1,
    "field_id": -1,
    "growth_id": -1,
    "moisture_id": -1,
    "disease_id": -1,
    "pest_id": -1,
    "collector": -1,
    "collect_date": "2018-08-28T00:00:00",
    "gps": {
      "X": 36.546,
      "Y": 114.125,
      "SRID": 0
    },
    "picture": ""
  },{
    "id": 3,
    "farm_id": -1,
    "field_id": -1,
    "growth_id": -1,
    "moisture_id": -1,
    "disease_id": -1,
    "pest_id": -1,
    "collector": -1,
    "collect_date": "2018-08-28T00:00:00",
    "gps": {
      "X": 36.546,
      "Y": 114.125,
      "SRID": 4326
    },
    "picture": ""
  }]
}
```

## News

### GetNewsByType

**访问地址**

```
 api/v1/news?type=type&limit=limit&offset=offset
```

**接口描述**

获取新闻信息。

**请求参数**

```
type：新闻类型

limit：获取条数

offset：起始位置
```

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

无。

**返回值**

指定类型的新闻列表。

*响应示例*

```
{
  "status": true,
  "msg": "succeed",
  "data": [{
    "id": 4,
    "news_type": 1,
    "summary": "test news 4",
    "news_date": "2000-01-01T00:00:00",
    "url": "http://123.com",
    "thumb_url": "http://123.com"
  }, {
    "id": 1,
    "news_type": 1,
    "summary": "test news 1",
    "news_date": "2018-08-24T00:00:00",
    "url": "http://123.com",
    "thumb_url": "http://123.com"
  }]
}
```

## FeedBacks

### PostFeedBack

**访问地址**

```
 api/v1/feedbacks
```

**接口描述**

提交意见反馈。

**请求参数**

无。

**请求头**

必须包含以下字段。

```
{
    Authorization:授权接口返回的token
}
```

**请求体**

feedback对象。

*请求示例*

```
{
    "id":1
    "user_id": 1,
    "suggestion": "建议建议",
    "thumb_url": "*.jpg",
    "create_date": "2018-08-28",
}
```

**返回值**

返回执行状态。

*响应示例*

```
```
{
	"status": true,
	"msg": "succeed",
	"data": null
}
```
```