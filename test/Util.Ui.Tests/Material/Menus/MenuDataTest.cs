﻿using Util.Ui.Material.Menus.Datas;
using Xunit;

namespace Util.Ui.Tests.Material.Menus {
    /// <summary>
    /// 菜单数据测试
    /// </summary>
    public class MenuDataTest {
        /// <summary>
        /// 菜单节点集合
        /// </summary>
        private readonly MenuNodeCollection _nodes;

        /// <summary>
        /// 测试初始化
        /// </summary>
        public MenuDataTest() {
            _nodes = new MenuNodeCollection();
        }

        /// <summary>
        /// 转换为菜单数据列表
        /// </summary>
        [Fact]
        public void TestToMenuDatas_1() {
            _nodes.Nodes.Add( new MenuNode { Text = "a" } );
            var datas = _nodes.ToMenuDatas();
            Assert.Single( datas );
            Assert.Single( datas[0].Items );
            Assert.Equal( _nodes.RootId, datas[0].Id );
            Assert.Equal( "a", datas[0].Items[0].Text );
        }

        /// <summary>
        /// 转换为菜单数据列表
        /// </summary>
        [Fact]
        public void TestToMenuDatas_2() {
            _nodes.Nodes.Add( new MenuNode { Text = "a" } );
            _nodes.Nodes.Add( new MenuNode { Text = "b" } );
            var datas = _nodes.ToMenuDatas();
            Assert.Single( datas );
            Assert.Equal( 2, datas[0].Items.Count );
            Assert.Equal( "a", datas[0].Items[0].Text );
            Assert.Equal( "b", datas[0].Items[1].Text );
        }

        /// <summary>
        /// 转换为菜单数据列表
        /// </summary>
        [Fact]
        public void TestToMenuDatas_3() {
            _nodes.Nodes.Add( new MenuNode { Id = "1", Text = "a" } );
            _nodes.Nodes.Add( new MenuNode { Id = "2", Text = "b" } );
            _nodes.Nodes.Add( new MenuNode { ParentId = "2", Text = "c" } );
            var datas = _nodes.ToMenuDatas();
            Assert.Equal( 2, datas.Count );
            Assert.Equal( 2, datas[0].Items.Count );
            Assert.Single( datas[1].Items );
            Assert.Equal( "a", datas[0].Items[0].Text );
            Assert.Equal( "b", datas[0].Items[1].Text );
            Assert.Equal( "c", datas[1].Items[0].Text );
            Assert.True( datas[0].Items[0].MenuId.IsEmpty() );
            Assert.Equal( "m_2", datas[0].Items[1].MenuId );
        }

        /// <summary>
        /// 转换为菜单数据列表
        /// </summary>
        [Fact]
        public void TestToMenuDatas_4() {
            _nodes.Nodes.Add( new MenuNode { Id = "1", Text = "a" } );
            _nodes.Nodes.Add( new MenuNode { Id = "2", Text = "b" } );
            _nodes.Nodes.Add( new MenuNode { Id = "3", ParentId = "2", Text = "c" } );
            _nodes.Nodes.Add( new MenuNode { ParentId = "3", Text = "d" } );
            var datas = _nodes.ToMenuDatas();
            Assert.Equal( 3, datas.Count );
            Assert.Equal( 2, datas[0].Items.Count );
            Assert.Single( datas[1].Items );
            Assert.Single( datas[2].Items );
            Assert.True( datas[0].Items[0].MenuId.IsEmpty() );
            Assert.Equal( "m_2", datas[0].Items[1].MenuId );
            Assert.Equal( "m_3", datas[1].Items[0].MenuId );
            Assert.True( datas[2].Items[0].MenuId.IsEmpty() );
        }
    }
}
