using DomainModel.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Test.Users
{
    [TestClass]
    public class UserRolePolicyTest
    {
        [TestMethod]
        public void エディターはチャンネル追加ができる()
        {
            var canDo = RolePolicy.CanDo(Role.Editor, Aggregate.Channel, UseCase.Add);
            Assert.IsTrue(canDo);
        }

        [TestMethod]
        public void エディターはチャンネル削除ができない()
        {
            var canDo = RolePolicy.CanDo(Role.Editor, Aggregate.Channel, UseCase.Remove);
            Assert.IsFalse(canDo);
        }

        [TestMethod]
        public void エディターは動画追加ができる()
        {
            var canDo = RolePolicy.CanDo(Role.Editor, Aggregate.Video, UseCase.Add);
            Assert.IsTrue(canDo);
        }

        [TestMethod]
        public void エディターはビデオ削除ができない()
        {
            var canDo = RolePolicy.CanDo(Role.Editor, Aggregate.Video, UseCase.Remove);
            Assert.IsFalse(canDo);
        }

        [TestMethod]
        public void メンテナーは動画追加ができる()
        {
            var canDo = RolePolicy.CanDo(Role.Maintainer, Aggregate.Video, UseCase.Add);
            Assert.IsTrue(canDo);
        }

        [TestMethod]
        public void メンテナーは動画削除ができる()
        {
            var canDo = RolePolicy.CanDo(Role.Maintainer, Aggregate.Video, UseCase.Remove);
            Assert.IsTrue(canDo);
        }
    }
}
