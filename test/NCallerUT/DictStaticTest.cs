﻿using Natasha;
using NCaller;
using NCallerUT.Model;
using System;
using Xunit;

namespace NCallerUT
{
    [Trait("DictOperator", "静态类")]
    public class DictStaticTest
    {
        [Fact(DisplayName = "动态生成类")]
        public void TestCall1()
        {
            //ScriptComplier.Init();
            string text = @"using System;
using System.Collections;
using System.Linq;
using System.Text;
 
namespace HelloWorld
{
    public static class StaticTest2
    {
        static StaticTest2(){
            Name=""111"";
        }

        public static string Name;
        public static int Age{get;set;}
    }
}";
            //根据脚本创建动态类
            Type type =(new OopComplier()).GetClassType(text);
            //创建动态类实例代理
            var instance = DictOperator.Create(type);
            //Get动态调用
            Assert.Equal("111", (string)instance["Name"]);
            //调用动态委托赋值
            instance["Name"] = "222";

            Assert.Equal("222", (string)instance["Name"]);
            Assert.Equal("222", instance.Get<string>("Name"));
        }



        [Fact(DisplayName = "运行时静态类")]
        public void TestCall2()
        {
            //创建动态类实例代理
            var instance = DictOperator.Create(typeof(StaticTestModel2));
            StaticTestModel2.Name = "111";
            Assert.Equal("111", (string)instance["Name"]);
            instance["Name"] = "222";
            Assert.Equal("222", (string)instance["Name"]);
            StaticTestModel2.Age = 1001;
            Assert.Equal(1001, (int)instance["Age"]);
            StaticTestModel2.Temp = DateTime.Now;
            instance["Temp"] = StaticTestModel2.Temp;
            Assert.Equal(StaticTestModel2.Temp, (DateTime)instance["Temp"]);

        }

        [Fact(DisplayName = "运行时伪静态类")]
        public void TestCall3()
        {
            //创建动态类实例代理
            var instance = DictOperator.Create(typeof(FakeStaticTestModel2));
            FakeStaticTestModel2.Name = "111";
            Assert.Equal("111", (string)instance["Name"]);
            instance["Name"] = "222";
            Assert.Equal("222", (string)instance["Name"]);
            FakeStaticTestModel2.Age = 1001;
            Assert.Equal(1001, (int)instance["Age"]);
            FakeStaticTestModel2.Temp = DateTime.Now;
            instance["Temp"] = FakeStaticTestModel2.Temp;
            Assert.Equal(FakeStaticTestModel2.Temp, (DateTime)instance["Temp"]);

        }
    }
}
