import { _ as _export_sfc, c as createElementBlock, o as openBlock, a as createStaticVNode } from "./app.f7763073.js";
const __pageData = '{"title":"Shuttle.Core.Logging","description":"","frontmatter":{"title":"Shuttle.Core.Logging","layout":"api"},"headers":[{"level":2,"title":"Assign","slug":"assign"},{"level":2,"title":"AssignTransient","slug":"assigntransient"}],"relativePath":"logging/shuttle-core-logging.md"}';
const _sfc_main = {};
const _hoisted_1 = /* @__PURE__ */ createStaticVNode('<h1 id="shuttle-core-logging" tabindex="-1">Shuttle.Core.Logging <a class="header-anchor" href="#shuttle-core-logging" aria-hidden="true">#</a></h1><div class="language-"><pre><code>PM&gt; Install-Package Shuttle.Core.Logging\n</code></pre></div><p>The Shuttle.Core.Logging project provides an abstract mechanism that can be used to implement any logging such as a Log4Net implementation. You would typically reference this package directly when you need to create your own <code>ILog</code> implementation. You <em>may</em> wish to make use of the <code>ConsoleLog</code> or <code>EventLog</code> implementations in this package from time-to-time.</p><p>In this way all logging can be performed through the <code>ILog</code> interface and accompanying <code>Log</code> singleton without relying on any specific implementation. Developer can then make use any implementation.</p><p>Since there is some boilerplate code implementors may make use of the <code>AbstractLog</code> class to implement a new concrete logging mechanism:</p><div class="language-c#"><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#C792EA;">abstract</span><span style="color:#A6ACCD;"> </span><span style="color:#F78C6C;">class</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">AbstractLog</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">:</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">ILog</span></span>\n<span class="line"><span style="color:#89DDFF;">{</span></span>\n<span class="line"><span style="color:#89DDFF;">    </span><span style="color:#676E95;font-style:italic;">// boilerplate</span></span>\n<span class="line"><span style="color:#89DDFF;">}</span></span>\n<span class="line"></span></code></pre></div><h1 id="assigning-a-logging-mechanism" tabindex="-1">Assigning a logging mechanism <a class="header-anchor" href="#assigning-a-logging-mechanism" aria-hidden="true">#</a></h1><p>If no log is assigned or if a <code>null</code> is assigned the <code>NullLog.Instance</code> will be used. As may be deduced from the name this log does not do anything.</p><h2 id="assign" tabindex="-1">Assign <a class="header-anchor" href="#assign" aria-hidden="true">#</a></h2><div class="language-c#"><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#C792EA;">static</span><span style="color:#A6ACCD;"> </span><span style="color:#89DDFF;">void</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">Assign</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">ILog</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">instance</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div><p>This assigns the log to use for the duration of the execution.</p><h2 id="assigntransient" tabindex="-1">AssignTransient <a class="header-anchor" href="#assigntransient" aria-hidden="true">#</a></h2><div class="language-c#"><pre><code><span class="line"><span style="color:#C792EA;">public</span><span style="color:#A6ACCD;"> </span><span style="color:#C792EA;">static</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">TransientLog</span><span style="color:#A6ACCD;"> </span><span style="color:#82AAFF;">AssignTransient</span><span style="color:#89DDFF;">(</span><span style="color:#FFCB6B;">ILog</span><span style="color:#A6ACCD;"> </span><span style="color:#FFCB6B;">instance</span><span style="color:#89DDFF;">)</span></span>\n<span class="line"></span></code></pre></div><p>Returns a <code>IDisposable</code> instance that returns the log to the previous instance on dispose. This may be usefull for testing purposes where you may want to use a mock object and ensure that certain bits are logged.</p><h1 id="consolelog" tabindex="-1">ConsoleLog <a class="header-anchor" href="#consolelog" aria-hidden="true">#</a></h1><p>The <code>ConsoleLog</code> class outputs all loggin go the console window.</p><h1 id="eventlog" tabindex="-1">EventLog <a class="header-anchor" href="#eventlog" aria-hidden="true">#</a></h1><p>The <code>EventLog</code> class provides hooks by way of the <code>LoggerDelegate</code> that allows simple access to the logged messages.</p>', 18);
const _hoisted_19 = [
  _hoisted_1
];
function _sfc_render(_ctx, _cache, $props, $setup, $data, $options) {
  return openBlock(), createElementBlock("div", null, _hoisted_19);
}
var shuttleCoreLogging = /* @__PURE__ */ _export_sfc(_sfc_main, [["render", _sfc_render]]);
export { __pageData, shuttleCoreLogging as default };