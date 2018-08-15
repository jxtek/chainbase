using System.Threading.Tasks;
using Greatbone;
using static Samp.User;
using static Greatbone.Modal;

namespace Samp
{
    [UserAccess(true)]
    public class MyWork : Work
    {
        public MyWork(WorkConfig cfg) : base(cfg)
        {
            CreateVar<MyVarWork, int>((obj) => ((User) obj).id);
        }
    }

    [UserAccess(ctr: 1)]
    [Ui("人员")]
    public class CtrWork : UserWork<CtrUserVarWork>
    {
        public CtrWork(WorkConfig cfg) : base(cfg)
        {
            Create<CtrOrderWork>("mgro");

            Create<GvrOrderWork>("gvro");

            Create<DvrOrderWork>("dvro");

            Create<CtrItemWork>("item");

            Create<CtrOrgWork>("org");

            Create<CtrRepayWork>("repay");
        }

        public void @default(WebContext wc)
        {
            bool inner = wc.Query[nameof(inner)];
            if (inner)
            {
                using (var dc = NewDbContext())
                {
                    dc.Sql("SELECT * FROM users WHERE ctr > 0 ORDER BY ctr");
                    var arr = dc.Query<User>();
                    wc.GivePage(200, h =>
                    {
                        h.TOOLBAR();
                        h.TABLE(arr, null,
                            o => h.TD(o.name).TD(o.tel).TD(Ctrs[o.ctr])
                        );
                    });
                }
            }
            else
            {
                wc.GiveFrame(200, false, 60 * 15, "调度作业");
            }
        }

        [UserAccess(CTR_MGR)]
        [Ui("添加", "添加中心操作人员"), Tool(ButtonShow, size: 1)]
        public async Task add(WebContext wc, int cmd)
        {
            string tel = null;
            short ctr = 0;
            if (wc.GET)
            {
                wc.GivePane(200, h =>
                {
                    h.FORM_();
                    h.FIELDUL_("添加人员");
                    h.LI_().TEXT("手　机", nameof(tel), tel, pattern: "[0-9]+", max: 11, min: 11)._LI();
                    h.LI_().SELECT("角　色", nameof(ctr), ctr, Ctrs)._LI();
                    h._FIELDUL();
                    h._FORM();
                });
            }
            else
            {
                if (cmd == 2) // add
                {
                    using (var dc = NewDbContext())
                    {
                        dc.Execute("UPDATE users SET ctr = @1 WHERE tel = @2", p => p.Set(ctr).Set(tel));
                    }
                }
                wc.GivePane(200);
            }
        }
    }

    public class GrpWork : Work
    {
        public GrpWork(WorkConfig cfg) : base(cfg)
        {
            CreateVar<GrpVarWork, string>(prin => ((User) prin).grpat);
        }
    }
}