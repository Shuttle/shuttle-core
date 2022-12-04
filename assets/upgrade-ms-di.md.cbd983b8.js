import { _ as _export_sfc, o as openBlock, c as createElementBlock, d as createStaticVNode } from "./app.606b2888.js";
const __pageData = JSON.parse('{"title":"Breaking Changes","description":"","frontmatter":{},"headers":[],"relativePath":"upgrade-ms-di.md"}');
const _sfc_main = { name: "upgrade-ms-di.md" };
const _hoisted_1 = /* @__PURE__ */ createStaticVNode('<h1 id="breaking-changes" tabindex="-1">Breaking Changes <a class="header-anchor" href="#breaking-changes" aria-hidden="true">#</a></h1><p>With the introduction of <a href="https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection" target="_blank">.NET dependency injection</a> as well as the <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options" target="_blank">options pattern</a> into the <code>Shuttle.Core</code> components, some packages are no longer required and support for them will be dropped in due course.</p><p>These include the <code>Shuttle.Core.Container</code>, <code>Shuttle.Core.Logging</code>, generic hosting, as well as all related and derived packages.</p><p>Logging is no longer directly implemented in any of the components. Instead, where required, events are raised that may be handled in client applications where the appropriate <a href="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging" target="_blank">logging</a> should occur.</p><p>Please see the documentation for each of the relevant packages to see how to make use of them now.</p>', 5);
const _hoisted_6 = [
  _hoisted_1
];
function _sfc_render(_ctx, _cache, $props, $setup, $data, $options) {
  return openBlock(), createElementBlock("div", null, _hoisted_6);
}
const upgradeMsDi = /* @__PURE__ */ _export_sfc(_sfc_main, [["render", _sfc_render]]);
export {
  __pageData,
  upgradeMsDi as default
};
