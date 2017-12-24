﻿using System.Threading.Tasks;
using Greatbone.Core;
using static Greatbone.Core.Modal;
using static Greatbone.Samp.User;

namespace Greatbone.Samp
{
    public abstract class ItemWork<V> : Work where V : ItemVarWork
    {
        protected ItemWork(WorkConfig cfg) : base(cfg)
        {
            CreateVar<V, string>(obj => ((Item) obj).name);
        }
    }


    [Ui("货品"), User(OPRMEM)]
    public class OprItemWork : ItemWork<OprItemVarWork>
    {
        public OprItemWork(WorkConfig wc) : base(wc)
        {
        }

        public void @default(ActionContext ac)
        {
            string shopid = ac[-1];
            using (var dc = ac.NewDbContext())
            {
                dc.Query("SELECT * FROM items WHERE shopid = @1 ORDER BY status DESC", p => p.Set(shopid));
                ac.GiveBoardPage(200, dc.ToArray<Item>(), (h, o) =>
                {
                    h.CAPTION(o.name, Item.Statuses[o.status], o.status >= Item.ON);
                    h.ICON(o.name + "/icon", box: 3);
                    h.BOX_(0x49).P(o.descr, "描述").P(o.content, "主含").P(o.price, "单价", "¥")._BOX();
                    h.FIELD(o.unit, "单位", box: 3).FIELD(o.min, "起订", box: 3).FIELD(o.step, "增减", box: 3).FIELD(o.stock, "剩量", box: 3);
                    h.TAIL();
                });
            }
        }

        [Ui("新建"), Tool(ButtonShow, 2), User(OPRMEM)]
        public async Task @new(ActionContext ac)
        {
            if (ac.GET)
            {
                var o = new Item {min = 1, step = 1};
                ac.GivePane(200, m =>
                {
                    m.FORM_();
                    m.TEXT(nameof(o.name), o.name, label: "名称", max: 10, required: true);
                    m.TEXTAREA(nameof(o.descr), o.descr, "简述", max: 30, required: true);
                    m.TEXT(nameof(o.content), o.content, "主含", max: 10, required: true);
                    m.TEXT(nameof(o.unit), o.unit, "单位", required: true, box: 6).NUMBER(nameof(o.price), o.price, "单价", required: true, box: 6);
                    m.NUMBER(nameof(o.min), o.min, "起订", min: (short) 1, box: 6).NUMBER(nameof(o.step), o.step, "增减", min: (short) 1, box: 6);
                    m.SELECT(nameof(o.status), o.status, Item.Statuses, "状态", box: 6).NUMBER(nameof(o.stock), o.stock, "剩量", box: 6);
                    m._FORM();
                });
            }
            else // POST
            {
                var o = await ac.ReadObjectAsync<Item>();
                o.shopid = ac[-1];
                using (var dc = ac.NewDbContext())
                {
                    dc.Execute(dc.Sql("INSERT INTO items")._(Item.Empty)._VALUES_(Item.Empty), p => o.Write(p));
                }
                ac.GivePane(200); // close dialog
            }
        }

        [Ui("删除"), Tool(ButtonPickConfirm), User(OPRMEM)]
        public async Task del(ActionContext ac)
        {
            short shopid = ac[-1];
            var f = await ac.ReadAsync<Form>();
            string[] key = f[nameof(key)];
            if (key != null)
            {
                using (var dc = ac.NewDbContext())
                {
                    dc.Execute(dc.Sql("DELETE FROM items WHERE shopid = @1 AND name")._IN_(key), p => p.Set(shopid), false);
                }
            }
            ac.GiveRedirect();
        }
    }
}