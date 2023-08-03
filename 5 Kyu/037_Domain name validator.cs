/*Challenge link:https://www.codewars.com/kata/5893933e1a88084be10001a3/train/csharp
Question:
In this kata you have to create a domain name validator mostly compliant with RFC 1035, RFC 1123, and RFC 2181

For purposes of this kata, following rules apply:

Domain name may contain subdomains (levels), hierarchically separated by . (period) character
Domain name must not contain more than 127 levels, including top level (TLD)
Domain name must not be longer than 253 characters (RFC specifies 255, but 2 characters are reserved for trailing dot and null character for root level)
Level names must be composed out of lowercase and uppercase ASCII letters, digits and - (minus sign) character
Level names must not start or end with - (minus sign) character
Level names must not be longer than 63 characters
Top level (TLD) must not be fully numerical
Additionally, in this kata

Domain name must contain at least one subdomain (level) apart from TLD
Top level validation must be naive - ie. TLDs nonexistent in IANA register are still considered valid as long as they adhere to the rules given above.
The validation function accepts string with the full domain name and returns boolean value indicating whether the domain name is valid or not.

Examples:

validate('codewars') == False
validate('g.co') == True
validate('codewars.com') == True
validate('CODEWARS.COM') == True
validate('sub.codewars.com') == True
validate('codewars.com-') == False
validate('.codewars.com') == False
validate('example@codewars.com') == False
validate('127.0.0.1') == False
*/

//***************Solution********************

using System.Text.RegularExpressions;

public class DomainNameValidator {
  public bool validate(string domain) {
    //Check if domain name contains more than 253 characters
    if (domain.Length > 253)
      return false;
    
    //check for match using regex expression
    //^(?!-)[a-z0-9-]{1,63}      (?<!-)  (?:\.(?!-)[a-z0-9-]{1,63}(?<!-))   {0,125}  \.
    //start of the string ^
    //group ?! negative lookahead "-", range from a-z 0-9 and -, between 1 to 63 characters.
    //group ?<! negative lookbehind "-"
    //group negative lookahead "\.", negative lookahead "-", range a-z 0-9, between 1 to 63 characters., negative lookhead "-"
    //check the previous express is between 0 to 125 characters.
    //group (?:\.(?!-)[a-z0-9-]{1,63}(?<!-))
    // followed by "\."
    
    //(?!-)  (?![0-9]+$)[a-z0-9-]{1,63}  (?<!-)$
    //group ?! negative lookahead "-"
    //group ?! negative lookahead "0-9", + appear one or more, range from a-z 0-9 and "-", between 1 to 63 characters.
    //group ?<! negative lookbehind "-"
    //end of string $
    
    var regex = new Regex(@"^(?!-)[a-z0-9-]{1,63}(?<!-)(?:\.(?!-)[a-z0-9-]{1,63}(?<!-)){0,125}\.(?!-)(?![0-9]+$)[a-z0-9-]{1,63}(?<!-)$", RegexOptions.IgnoreCase);
    return regex.IsMatch(domain);
  }
}
//****************Sample Test*****************
namespace CodeWars {
  using NUnit.Framework;
  using System;
  [TestFixture]
  public class DomainNameValidatorTest
  {
    DomainNameValidator v = new DomainNameValidator();
    
    [Test]
    public void LengthTests()
    {
      Assert.AreEqual(false, v.validate("codewars"));
      Assert.AreEqual(true, v.validate("g.co"));
      Assert.AreEqual(true, v.validate("subdomain.codewars.com"));
      Assert.AreEqual(true, v.validate("some-horribly-long-domain-name-but-still-shorter-than-63-ch.zzz"));
      Assert.AreEqual(false, v.validate("some-horribly-long-domain-name-this-time-longer-than-63-charaters.zzz"));
      Assert.AreEqual(true, v.validate("some.horribly.long.domain.name.which.has.a.bunch.of.subdomains.to.be.long.enough.to.exceed.128.characters.but.is.still.shorter.than.253.characters"));
      Assert.AreEqual(false, v.validate("some.horribly.long.subdomain.name.which.has.incredible.amount.of.subdomains.and.is.so.long.that.not.only.it.exceeds.128.characters.like.the.test.above.but.it.actually.manages.to.exceed.also.the.maximum.limit.of.253.characters.required.by.the.instructions"));
      Assert.AreEqual(true, v.validate("a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w"));
      Assert.AreEqual(false, v.validate("a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x.y.z.a.b.c.d.e.f.g.h.i.j.k.l.m.n.o.p.q.r.s.t.u.v.w.x"));
    }
    
    [Test]
    public void DashTests() {
      Assert.AreEqual(true, v.validate("xn--example-kva.meow"));
      Assert.AreEqual(true, v.validate("code-wars.com"));
      Assert.AreEqual(true, v.validate("sub-domain.code-wars.com"));
      Assert.AreEqual(false, v.validate("example.-com"));
      Assert.AreEqual(false, v.validate("example.com-"));
      Assert.AreEqual(false, v.validate("-example.com"));
      Assert.AreEqual(false, v.validate("example-com"));
      Assert.AreEqual(false, v.validate("subdomain-.example.com"));
    }
    
    [Test]
    public void DotTests() {
      Assert.AreEqual(false, v.validate("."));
      Assert.AreEqual(false, v.validate(".com"));
      Assert.AreEqual(false, v.validate(".example.com"));
      Assert.AreEqual(false, v.validate("example."));
      Assert.AreEqual(false, v.validate("example.com."));
      Assert.AreEqual(false, v.validate("example..com"));
    }
    
    [Test]
    public void CharacterTest() {
      Assert.AreEqual(true, v.validate("EXAMPLE.COM"));
      Assert.AreEqual(false, v.validate("example:com"));
      Assert.AreEqual(false, v.validate("_http._sctp.example.com"));
      Assert.AreEqual(false, v.validate("example@example.com"));
      Assert.AreEqual(true, v.validate("1234.com"));
      Assert.AreEqual(true, v.validate("1.1.168.192.in-addr.arpa"));
      Assert.AreEqual(false, v.validate("127.0.0.1"));
      Assert.AreEqual(false, v.validate("mňau.cz"));
    }
    
    [Test]
    public void TLDTest() {
      Assert.AreEqual(true, v.validate("example.a"));
      Assert.AreEqual(true, v.validate("example.a1b"));
      Assert.AreEqual(true, v.validate("example.1ab"));
      Assert.AreEqual(true, v.validate("example.ab1"));
      Assert.AreEqual(true, v.validate("example.1a2"));
      Assert.AreEqual(true, v.validate("example.1-2"));
      Assert.AreEqual(false, v.validate("example.123"));
    }
  }
}
