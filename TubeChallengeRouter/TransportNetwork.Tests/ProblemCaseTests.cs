namespace StationTests;

[TestFixture]
public class ProblemCaseTests
{
    private Network _network;
    
    [SetUp]
    public void SetUp()
    {
        ILogger stubLogger = new LoggerConfiguration().CreateLogger();
        _network = new NetworkFactory(new TflModelWrapper(stubLogger, "./")).Generate(NetworkType.Dijkstra, stubLogger);
    }

    [Test]
    public void ProblemCase_CostPositive()
    {
        List<string> stations =
            "940GZZLUEGW;940GZZLUNGW;940GZZLURSP;940GZZLUWIG;940GZZLUBND;940GZZLUWRR;940GZZLUBZP;940GZZLUKSH;940GZZLUNWH;940GZZLUBWR;940GZZLUERB;940GZZLUBMY;940GZZLUMED;940GZZLUWSM;940GZZLUBST;940GZZLUBTX;940GZZLUMVL;940GZZLUSWK;940GZZLUWLO;940GZZLULSQ;940GZZLUSKS;940GZZLUWKN;940GZZLUUPK;940GZZLUEMB;940GZZLUHAI;940GZZLULYN;940GZZLUCPN;940GZZLUWHW;940GZZLURYL;940GZZLUECT;940GZZLUNWY;940GZZLUWKA;940GZZLUTAW;940GZZLUGDG;940GZZLUKNG;940GZZLUCND;940GZZLUBOS;940GZZLUEAN;940GZZLUWOP;940GZZLUMYB;940GZZLUNKP;940GZZLUPSG;940GZZLUBNK;940GZZLULRD;940GZZLUHBT;940GZZLUEFY;940GZZLUWHM;940GZZLUEAC;940GZZLUVXL;940GZZLUSKW;940GZZLUCPC;940GZZLUCFM;940GZZLUGTR;940GZZLUPRD;940GZZLUSJW;940GZZLUMDN;940GZZLUGPS;940GZZLUSBC;940GZZLUWTA;940GZZLUSWC;940GZZLUWSD;940GZZLUMGT;940GZZLUCAR;940GZZLUSKT;940GZZLUKPK;940GZZLUHPK;940GZZLUWWL;940GZZLUHSK;940GZZLUNFD;940GZZLUCYF;940GZZLUCPS;940GZZLUMRH;940GZZLUBLR;940GZZLUBLG;940GZZLUWYP;940GZZLUQBY;940GZZLUOXC;940GZZNEUGST;940GZZLUUXB;940GZZLUHGD;940GZZLUASL;940GZZLUCKS;940GZZLUTMP;940GZZLUGGN;940GZZLUOAK;940GZZLUADE;940GZZLUGGH;940GZZLUUPY;940GZZLUBKF;940GZZLUPCO;940GZZLUNEN;940GZZLUSFS;940GZZLUSBM;940GZZLUWIP;940GZZLUEBY;940GZZLUFCN;940GZZLURSQ;940GZZLUHCL;940GZZLUBWT;940GZZLUHR4;940GZZLUACT;940GZZLUSEA;940GZZLUBXN;940GZZLUCSD;940GZZLUECM;940GZZLUWBN;940GZZLUKNB;940GZZLUOSY;940GZZLUSGT;940GZZLUWOG;940GZZLUWLA;940GZZLURSG;940GZZLUPVL;940GZZLUFPK;940GZZLURKW;940GZZLUEAE;940GZZLUCPK;940GZZLUFYR;940GZZLUCWR;940GZZLUBSC;940GZZLUGBY;940GZZLUASG;940GZZLUBOR;940GZZLULVT;940GZZLUSUT;940GZZLUWCY;940GZZLUCWP;940GZZLUKSX;940GZZLUHWC;940GZZLUTPN;940GZZLUGTH;940GZZLUMMT;940GZZLUWAF;940GZZLUKSL;940GZZLUWJN;940GZZLUGHK;940GZZLUHWY;940GZZLUWSP;940GZZLUHSN;940GZZLUSSQ;940GZZLUMBA;940GZZLUWRP;940GZZLUGFD;940GZZLURGP;940GZZLUSTM;940GZZLUDOH;940GZZLUNDN;940GZZLUACY;940GZZLUNBP;940GZZLUBKE;940GZZLUWOF;940GZZLUMSH;940GZZLUPAH;940GZZLUNHA;940GZZLUCHL;940GZZLUQPS;940GZZLUHPC;940GZZLUHGR;940GZZLUCXY;940GZZLUHOH;940GZZLUCYD;940GZZLUPNR;940GZZLUNOW;940GZZLUEUS;940GZZLUBBN;940GZZLUBDS;940GZZLUHBN;940GZZLURYO;940GZZLUHGT;940GZZLUHTD;940GZZLUTFP;940GZZLUGPK;940GZZLUTNG;940GZZLUSFB;940GZZLUPCC;940GZZLUKBN;940GZZLUVIC;940GZZLUNAN;940GZZLUPAC;940GZZLUDGE;940GZZLUPLW;940GZZLUTMH;940GZZLUESQ;940GZZLUDBN;940GZZLUEHM;940GZZLULYS;940GZZLUWPL;940GZZLULGT;940GZZLUHLT;940GZZLUFLP;940GZZLUSNB;940GZZLUBKH;940GZZLUSGN;940GZZLUSGP;940GZZLUNHG;940GZZLUSTD;940GZZLUUPB;940GZZLUMHL;940GZZLUEPK;940GZZLUHCH;940GZZLULGN;940GZZLUBEC;940GZZLUHR5;940GZZLUWIM;940GZZLUPYB;940GZZLUEPY;940GZZLUHAW;940GZZLUBLM;940GZZBPSUST;940GZZLUAGL;940GZZLUKEN;940GZZLURMD;940GZZLUKWG;940GZZLUKBY;940GZZLUHSD;940GZZLUDGY;940GZZLURBG;940GZZLUBBB;940GZZLURVY;940GZZLUUPM;940GZZLUCGN;940GZZLUTWH;940GZZLUALD;940GZZLUSPU;940GZZLUTBC;940GZZLUSVS;940GZZLUCGT;940GZZLUKOY;940GZZLUERC;940GZZLUODS;940GZZLUQWY;940GZZLULAD;940GZZLURVP;940GZZLUHWT;940GZZLUHNX;940GZZLUWYC;940GZZLUSWF;940GZZLUCWL;940GZZLUTHB;940GZZLUBKG;940GZZLUBTK;940GZZLUSJP;940GZZLUFYC;940GZZLUHRC;940GZZLUSHH;940GZZLUFBY;940GZZLUCST;940GZZLUEPG;940GZZLULNB;940GZZLUPKR;940GZZLULBN;940GZZLUCTN;940GZZLUTCR;940GZZLUCHX;940GZZLURSM;940GZZLUICK;940GZZLUNHT;940GZZLUSRP;940GZZLUWFN;940GZZLUOVL;940GZZLUMPK;940GZZLUAMS;940GZZLUCAL;940GZZLUHWE;940GZZLUCSM;940GZZLUSWN;940GZZLUTBY;940GZZLUSUH;940GZZLUALP;940GZZLUWHP;940GZZLUHSC;940GZZLUMTC"
                .Split(";").ToList();
        Route route = new Route(stations);
        _network.RecalculateRouteData(ref route);
        Assert.That(route.Cost, Is.EqualTo(343));
        
        _network.Swap(ref route, 240, 122);
        Assert.That(route.Cost, Is.GreaterThan(0));
    }
}