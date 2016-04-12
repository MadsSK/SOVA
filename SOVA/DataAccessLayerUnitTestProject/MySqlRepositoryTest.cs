using System;
using System.Linq;
using NUnit.Framework;
using DataAccessLayer;
using DomainModel;


namespace DataAccessLayerUnitTestProject
{

    public class MySqlRepositoryTest
    {
        private readonly IRepository _repository = new MySqlRepository();

        [Test]
        public void GetPostIDTest()
        {
            Assert.That(_repository.GetAnswer(19).Id.Equals(19));
        }

        [Test]
        public void GetPostCreationDateTest()
        {
            Assert.That(_repository.GetAnswer(19).CreationDate.Equals(
                new DateTime(2008, 08, 01, 05, 21, 22)));
        }

        [Test]
        public void GetPostScoreTest()
        {
            Assert.That(_repository.GetAnswer(19).Score.Equals(164));
        }

        [Test]
        public void GetPostBodyTest()
        {
            Assert.That(
                _repository.GetAnswer(19)
                    .Body.Equals(
                        @"< p > Solutions are welcome in any language. :-) I'm looking for the fastest way to obtain the value of π, as a personal challenge. More specifically I'm using ways that don't involve using <code>#define</code>d constants like <code>M_PI</code>, or hard-coding the number in.</p>&#xA;&#xA;<p>The program below tests the various ways I know of. The inline assembly version is, in theory, the fastest option, though clearly not portable; I've included it as a baseline to compare the other versions against.In my tests, with built-ins, the < code > 4 * atan(1) </ code > version is fastest on GCC 4.2, because it auto - folds the<code> atan(1) </ code > into a constant.With < code > -fno - builtin </ code > specified, the < code > atan2(0, -1) </ code > version is fastest.</ p > &#xA;&#xA;<p>Here's the main testing program (<code>pitimes.c</code>):</p>&#xA;&#xA;<pre><code>#include &lt;math.h&gt;&#xA;#include &lt;stdio.h&gt;&#xA;#include &lt;time.h&gt;&#xA;&#xA;#define ITERS 10000000&#xA;#define TESTWITH(x) {                                                       \&#xA;    diff = 0.0;                                                             \&#xA;    time1 = clock();                                                        \&#xA;    for (i = 0; i &lt; ITERS; ++i)                                             \&#xA;        diff += (x) - M_PI;                                                 \&#xA;    time2 = clock();                                                        \&#xA;    printf(""%s\t=&gt; %e, time =&gt; %f\n"", #x, diff, diffclock(time2, time1));   \&#xA;}&#xA;&#xA;static inline double&#xA;diffclock(clock_t time1, clock_t time0)&#xA;{&#xA;    return (double) (time1 - time0) / CLOCKS_PER_SEC;&#xA;}&#xA;&#xA;int&#xA;main()&#xA;{&#xA;    int i;&#xA;    clock_t time1, time2;&#xA;    double diff;&#xA;&#xA;    /* Warmup. The atan2 case catches GCC's atan folding (which would&#xA;     * optimise the ``4 * atan(1) - M_PI'' to a no-op), if -fno-builtin&#xA;     * is not used. */&#xA;    TESTWITH(4 * atan(1))&#xA;    TESTWITH(4 * atan2(1, 1))&#xA;&#xA;#if defined(__GNUC__) &amp;&amp; (defined(__i386__) || defined(__amd64__))&#xA;    extern double fldpi();&#xA;    TESTWITH(fldpi())&#xA;#endif&#xA;&#xA;    /* Actual tests start here. */&#xA;    TESTWITH(atan2(0, -1))&#xA;    TESTWITH(acos(-1))&#xA;    TESTWITH(2 * asin(1))&#xA;    TESTWITH(4 * atan2(1, 1))&#xA;    TESTWITH(4 * atan(1))&#xA;&#xA;    return 0;&#xA;}&#xA;</code></pre>&#xA;&#xA;<p>And the inline assembly stuff (<code>fldpi.c</code>), noting that it will only work for x86 and x64 systems:</p>&#xA;&#xA;<pre><code>double&#xA;fldpi()&#xA;{&#xA;    double pi;&#xA;    asm(""fldpi"" : ""=t"" (pi));&#xA;    return pi;&#xA;}&#xA;</code></pre>&#xA;&#xA;<p>And a build script that builds all the configurations I'm testing (<code>build.sh</code>):</p>&#xA;&#xA;<pre><code>#!/bin/sh&#xA;gcc -O3 -Wall -c           -m32 -o fldpi-32.o fldpi.c&#xA;gcc -O3 -Wall -c           -m64 -o fldpi-64.o fldpi.c&#xA;&#xA;gcc -O3 -Wall -ffast-math  -m32 -o pitimes1-32 pitimes.c fldpi-32.o&#xA;gcc -O3 -Wall              -m32 -o pitimes2-32 pitimes.c fldpi-32.o -lm&#xA;gcc -O3 -Wall -fno-builtin -m32 -o pitimes3-32 pitimes.c fldpi-32.o -lm&#xA;gcc -O3 -Wall -ffast-math  -m64 -o pitimes1-64 pitimes.c fldpi-64.o -lm&#xA;gcc -O3 -Wall              -m64 -o pitimes2-64 pitimes.c fldpi-64.o -lm&#xA;gcc -O3 -Wall -fno-builtin -m64 -o pitimes3-64 pitimes.c fldpi-64.o -lm&#xA;</code></pre>&#xA;&#xA;<p>Apart from testing between various compiler flags (I've compared 32-bit against 64-bit too, because the optimisations are different), I've also tried switching the order of the tests around. The <code>atan2(0, -1)</code> version still comes out top every time, though.</p>&#xA;"));
        }

        [Test]
        public void GetPostOwnerUserIdTest()
        {
            Assert.That(_repository.GetAnswer(19).OwnerUserId.Equals(13));
        }

        [Test]
        public void GetPostTest()
        {
            Assert.That(_repository.GetAnswer(19).Equals(
                new
                {
                    Id = 19,
                    CreationDate = new DateTime(2008, 08, 01, 05, 21, 22),
                    Score = 164,
                    Body =
                        @"< p > Solutions are welcome in any language. :-) I'm looking for the fastest way to obtain the value of π, as a personal challenge. More specifically I'm using ways that don't involve using <code>#define</code>d constants like <code>M_PI</code>, or hard-coding the number in.</p>&#xA;&#xA;<p>The program below tests the various ways I know of. The inline assembly version is, in theory, the fastest option, though clearly not portable; I've included it as a baseline to compare the other versions against.In my tests, with built-ins, the < code > 4 * atan(1) </ code > version is fastest on GCC 4.2, because it auto - folds the<code> atan(1) </ code > into a constant.With < code > -fno - builtin </ code > specified, the < code > atan2(0, -1) </ code > version is fastest.</ p > &#xA;&#xA;<p>Here's the main testing program (<code>pitimes.c</code>):</p>&#xA;&#xA;<pre><code>#include &lt;math.h&gt;&#xA;#include &lt;stdio.h&gt;&#xA;#include &lt;time.h&gt;&#xA;&#xA;#define ITERS 10000000&#xA;#define TESTWITH(x) {                                                       \&#xA;    diff = 0.0;                                                             \&#xA;    time1 = clock();                                                        \&#xA;    for (i = 0; i &lt; ITERS; ++i)                                             \&#xA;        diff += (x) - M_PI;                                                 \&#xA;    time2 = clock();                                                        \&#xA;    printf(""%s\t=&gt; %e, time =&gt; %f\n"", #x, diff, diffclock(time2, time1));   \&#xA;}&#xA;&#xA;static inline double&#xA;diffclock(clock_t time1, clock_t time0)&#xA;{&#xA;    return (double) (time1 - time0) / CLOCKS_PER_SEC;&#xA;}&#xA;&#xA;int&#xA;main()&#xA;{&#xA;    int i;&#xA;    clock_t time1, time2;&#xA;    double diff;&#xA;&#xA;    /* Warmup. The atan2 case catches GCC's atan folding (which would&#xA;     * optimise the ``4 * atan(1) - M_PI'' to a no-op), if -fno-builtin&#xA;     * is not used. */&#xA;    TESTWITH(4 * atan(1))&#xA;    TESTWITH(4 * atan2(1, 1))&#xA;&#xA;#if defined(__GNUC__) &amp;&amp; (defined(__i386__) || defined(__amd64__))&#xA;    extern double fldpi();&#xA;    TESTWITH(fldpi())&#xA;#endif&#xA;&#xA;    /* Actual tests start here. */&#xA;    TESTWITH(atan2(0, -1))&#xA;    TESTWITH(acos(-1))&#xA;    TESTWITH(2 * asin(1))&#xA;    TESTWITH(4 * atan2(1, 1))&#xA;    TESTWITH(4 * atan(1))&#xA;&#xA;    return 0;&#xA;}&#xA;</code></pre>&#xA;&#xA;<p>And the inline assembly stuff (<code>fldpi.c</code>), noting that it will only work for x86 and x64 systems:</p>&#xA;&#xA;<pre><code>double&#xA;fldpi()&#xA;{&#xA;    double pi;&#xA;    asm(""fldpi"" : ""=t"" (pi));&#xA;    return pi;&#xA;}&#xA;</code></pre>&#xA;&#xA;<p>And a build script that builds all the configurations I'm testing (<code>build.sh</code>):</p>&#xA;&#xA;<pre><code>#!/bin/sh&#xA;gcc -O3 -Wall -c           -m32 -o fldpi-32.o fldpi.c&#xA;gcc -O3 -Wall -c           -m64 -o fldpi-64.o fldpi.c&#xA;&#xA;gcc -O3 -Wall -ffast-math  -m32 -o pitimes1-32 pitimes.c fldpi-32.o&#xA;gcc -O3 -Wall              -m32 -o pitimes2-32 pitimes.c fldpi-32.o -lm&#xA;gcc -O3 -Wall -fno-builtin -m32 -o pitimes3-32 pitimes.c fldpi-32.o -lm&#xA;gcc -O3 -Wall -ffast-math  -m64 -o pitimes1-64 pitimes.c fldpi-64.o -lm&#xA;gcc -O3 -Wall              -m64 -o pitimes2-64 pitimes.c fldpi-64.o -lm&#xA;gcc -O3 -Wall -fno-builtin -m64 -o pitimes3-64 pitimes.c fldpi-64.o -lm&#xA;</code></pre>&#xA;&#xA;<p>Apart from testing between various compiler flags (I've compared 32-bit against 64-bit too, because the optimisations are different), I've also tried switching the order of the tests around. The <code>atan2(0, -1)</code> version still comes out top every time, though.</p>&#xA;",
                    OwnerUserId = 13
                }));
        }

        [Test]
        public void GetPostsTest()
        {
            Assert.That(_repository.GetAnswers("java").Count().Equals(1391), _repository.GetAnswers("java").Count().ToString());

        }
    }
}
