import { _ as _export_sfc, o as openBlock, c as createElementBlock, d as createStaticVNode, a as createBaseVNode } from "./app.7be1e3d0.js";
const __pageData = JSON.parse('{"title":"Shuttle.Core.Cron","description":"","frontmatter":{},"headers":[{"level":2,"title":"CronExpression","slug":"cronexpression","link":"#cronexpression","children":[]},{"level":2,"title":"Cron Samples","slug":"cron-samples","link":"#cron-samples","children":[]},{"level":2,"title":"Specifications","slug":"specifications","link":"#specifications","children":[]}],"relativePath":"infrastructure/shuttle-core-cron.md"}');
const _sfc_main = { name: "infrastructure/shuttle-core-cron.md" };
const _hoisted_1 = /* @__PURE__ */ createStaticVNode('<h1 id="shuttle-core-cron" tabindex="-1">Shuttle.Core.Cron <a class="header-anchor" href="#shuttle-core-cron" aria-hidden="true">#</a></h1><div class="language-"><button class="copy"></button><span class="lang"></span><pre><code><span class="line"><span style="color:#A6ACCD;">PM&gt; Install-Package Shuttle.Core.Cron</span></span>\n<span class="line"><span style="color:#A6ACCD;"></span></span></code></pre></div><p>Provides <a href="https://en.wikipedia.org/wiki/Cron" target="_blank" rel="noreferrer">cron</a> expression parsing:</p><div class="language-"><button class="copy"></button><span class="lang"></span><pre><code><span class="line"><span style="color:#A6ACCD;"> \u250C\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500 minute (0 - 59)</span></span>\n<span class="line"><span style="color:#A6ACCD;"> \u2502 \u250C\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500 hour (0 - 23)</span></span>\n<span class="line"><span style="color:#A6ACCD;"> \u2502 \u2502 \u250C\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500 day of the month (1 - 31)</span></span>\n<span class="line"><span style="color:#A6ACCD;"> \u2502 \u2502 \u2502 \u250C\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500 month (1 - 12)</span></span>\n<span class="line"><span style="color:#A6ACCD;"> \u2502 \u2502 \u2502 \u2502 \u250C\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500\u2500 day of the week (1 - 7): Sunday to Saturday </span></span>\n<span class="line"><span style="color:#A6ACCD;"> \u2502 \u2502 \u2502 \u2502 \u2502                                   </span></span>\n<span class="line"><span style="color:#A6ACCD;"> \u2502 \u2502 \u2502 \u2502 \u2502</span></span>\n<span class="line"><span style="color:#A6ACCD;"> \u2502 \u2502 \u2502 \u2502 \u2502</span></span>\n<span class="line"><span style="color:#A6ACCD;"> * * * * *</span></span>\n<span class="line"><span style="color:#A6ACCD;"></span></span></code></pre></div><p>This implementation starts from the <code>minute</code> field (so no <code>second</code>). Any seconds are removed from all dates that are used.</p><h2 id="cronexpression" tabindex="-1">CronExpression <a class="header-anchor" href="#cronexpression" aria-hidden="true">#</a></h2><div class="language-c#"><button class="copy"></button><span class="lang">c#</span><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">CronExpression</span><span style="color:#89DDFF;">(string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">expression</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> ISpecificationFactory specificationFactory </span><span style="color:#89DDFF;">=</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">null)</span><span style="color:#A6ACCD;"> : </span><span style="color:#F78C6C;">this</span><span style="color:#89DDFF;">(</span><span style="color:#A6ACCD;">expression</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> DateTime</span><span style="color:#89DDFF;">.</span><span style="color:#A6ACCD;">Now</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> specificationFactory</span><span style="color:#89DDFF;">);</span></span>\n<span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">CronExpression</span><span style="color:#89DDFF;">(string</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">expression</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">date</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> ISpecificationFactory specificationFactory </span><span style="color:#89DDFF;">=</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">null);</span></span>\n<span class="line"></span></code></pre></div><p>Creates a <code>CronExpression</code> instance and parses the given <code>expression</code>. The <code>date</code> specifies to root date from which to determine either the next or previous occurrence.</p><div class="language-c#"><button class="copy"></button><span class="lang">c#</span><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">NextOccurrence</span><span style="color:#89DDFF;">();</span></span>\n<span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">NextOccurrence</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">date</span><span style="color:#89DDFF;">);</span></span>\n<span class="line"></span></code></pre></div><p>Returns the next date that would follow the given <code>date</code>. This is accomplished by adding 1 muinute to the relevant date. If no date is provided the root date will be used. This method also sets the root date to the result.</p><div class="language-c#"><button class="copy"></button><span class="lang">c#</span><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">GetNextOccurrence</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">date</span><span style="color:#89DDFF;">);</span></span>\n<span class="line"></span></code></pre></div><p>Returns the next date that would follow the given <code>date</code>. If the given <code>date</code> satisfies the required specification(s) then the <code>date</code> is returned as-is.</p><div class="language-c#"><button class="copy"></button><span class="lang">c#</span><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">PreviousOccurrence</span><span style="color:#89DDFF;">();</span></span>\n<span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">PreviousOccurrence</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">date</span><span style="color:#89DDFF;">);</span></span>\n<span class="line"></span></code></pre></div><p>Returns the previous date that would precede the given <code>date</code>. This is accomplished by subtracting 1 muinute from the relevant date. If no date is provided the root date will be used. This method also sets the root date to the result.</p><div class="language-c#"><button class="copy"></button><span class="lang">c#</span><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">GetPreviousOccurrence</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">DateTime</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">date</span><span style="color:#89DDFF;">);</span></span>\n<span class="line"></span></code></pre></div><p>Returns the previous date that would precede the given <code>date</code>. If the given <code>date</code> satisfies the required specification(s) then the <code>date</code> is returned as-is.</p><h2 id="cron-samples" tabindex="-1">Cron Samples <a class="header-anchor" href="#cron-samples" aria-hidden="true">#</a></h2>', 17);
const _hoisted_18 = /* @__PURE__ */ createBaseVNode("p", { "day-of-week": "" }, "Format is {minute} {hour} {day-of-month} {month}", -1);
const _hoisted_19 = /* @__PURE__ */ createStaticVNode('<table><thead><tr><th>Field</th><th>Options</th></tr></thead><tbody><tr><td><code>minutes</code></td><td>0-59 , - * /</td></tr><tr><td><code>hours</code></td><td>0-23 , - * /</td></tr><tr><td><code>day-of-month</code></td><td>1-31 , - * ? / L W</td></tr><tr><td><code>month</code></td><td>1-12 or JAN-DEC , - * /</td></tr><tr><td><code>day-of-week</code></td><td>1-7 or SUN-SAT , - * ? / L #</td></tr></tbody></table><p>If <code>day-of-month</code> is specified then <code>day-of-week</code> should be <code>?</code> and vice-versa.</p><p>Examples:</p><div class="language-"><button class="copy"></button><span class="lang"></span><pre><code><span class="line"><span style="color:#A6ACCD;">* * * * * - is every minute of every hour of every day of every month</span></span>\n<span class="line"><span style="color:#A6ACCD;">5,10-12,17/5 * * * * - minute 5, 10, 11, 12, and every 5th minute after that</span></span>\n<span class="line"><span style="color:#A6ACCD;"></span></span></code></pre></div><h2 id="specifications" tabindex="-1">Specifications <a class="header-anchor" href="#specifications" aria-hidden="true">#</a></h2><p>Specifications need to implement <code>ISpecification&lt;CronField.Candidate&gt;</code>.</p><p>You may pass an implementation of the <code>ISpecificationFactory</code> as a parameter to the <code>CronExpression</code>. There is a <code>DefaultSpecificationFactory</code> that accepts a function callback in the constructor for scenarios where an explicit <code>ISpecificationFactory</code> implementation may not be warranted, e.g.:</p><div class="language-c#"><button class="copy"></button><span class="lang">c#</span><pre><code><span class="line"><span style="color:#F78C6C;">var</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">factory</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">=</span><span style="color:#A6ACCD;"> </span><span style="color:#F78C6C;">new</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">DefaultSpecificationFactory</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">parameters</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">=&gt;</span></span>\n<span class="line"><span style="color:#89DDFF;">{</span></span>\n<span class="line"><span style="color:#A6ACCD;">    </span><span style="color:#89DDFF;">return</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">!</span><span style="color:#A6ACCD;">parameters</span><span style="color:#89DDFF;">.</span><span style="color:#A6ACCD;">Expression</span><span style="color:#89DDFF;">.</span><span style="color:#82AAFF;">Equals</span><span style="color:#89DDFF;">(</span><span style="color:#89DDFF;">&quot;</span><span style="color:#C3E88D;">H</span><span style="color:#89DDFF;">&quot;</span><span style="color:#89DDFF;">,</span><span style="color:#A6ACCD;"> StringComparison</span><span style="color:#89DDFF;">.</span><span style="color:#A6ACCD;">InvariantCultureIgnoreCase</span><span style="color:#89DDFF;">)</span><span style="color:#A6ACCD;"> </span></span>\n<span class="line"><span style="color:#A6ACCD;">        </span><span style="color:#89DDFF;">?</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">null</span><span style="color:#A6ACCD;"> </span></span>\n<span class="line"><span style="color:#A6ACCD;">        </span><span style="color:#89DDFF;">:</span><span style="color:#A6ACCD;"> </span><span style="color:#F78C6C;">new</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">Specification</span><span style="color:#89DDFF;">&lt;</span><span style="color:#FFCB6B;">CronField</span><span style="color:#89DDFF;">.</span><span style="color:#FFCB6B;">Candidate</span><span style="color:#89DDFF;">&gt;(</span><span style="color:#FFCB6B;">candidate</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">=&gt;</span><span style="color:#A6ACCD;"> candidate</span><span style="color:#89DDFF;">.</span><span style="color:#A6ACCD;">Date</span><span style="color:#89DDFF;">.</span><span style="color:#A6ACCD;">Day </span><span style="color:#89DDFF;">%</span><span style="color:#A6ACCD;"> </span><span style="color:#F78C6C;">2</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">==</span><span style="color:#A6ACCD;"> </span><span style="color:#F78C6C;">0</span><span style="color:#89DDFF;">);</span></span>\n<span class="line"><span style="color:#89DDFF;">});</span></span>\n<span class="line"></span></code></pre></div>', 8);
const _hoisted_27 = [
  _hoisted_1,
  _hoisted_18,
  _hoisted_19
];
function _sfc_render(_ctx, _cache, $props, $setup, $data, $options) {
  return openBlock(), createElementBlock("div", null, _hoisted_27);
}
const shuttleCoreCron = /* @__PURE__ */ _export_sfc(_sfc_main, [["render", _sfc_render]]);
export {
  __pageData,
  shuttleCoreCron as default
};
