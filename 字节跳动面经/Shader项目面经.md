
**1. 什么是Stencil Buffer（模板缓存）？它在渲染管线中的作用是什么？**
Stencil Buffer（模板缓存）是一种每像素的缓冲区，用于在渲染过程中进行像素级的条件判断。它常用于实现遮罩、剪切、镜面等效果。通过Stencil Buffer，可以控制哪些像素被渲染、哪些被遮挡。

**2. 为什么在本项目中不能使用ShaderGraph，而要手写Shader？**
因为ShaderGraph主要用于可视化编辑Shader，但它对底层渲染管线的控制有限，无法灵活地操作Stencil Buffer等底层特性。而手写Shader可以直接控制渲染流程和所有渲染状态，满足特殊需求。

**3. 解释Unlit Shader的特点，以及它和Lit Shader的区别。**
Unlit Shader是“无光照”Shader，不受场景光照影响，渲染出来的颜色就是材质本身的颜色。Lit Shader会受到光源、阴影等影响，表现更真实。Unlit适合UI、特效、Mask等用途。

**4. 你如何通过Shader代码实现Stencil Buffer的写入和测试？请简述关键字段的作用（如Ref、Comp、Pass、Fail）。**在Shader中，Stencil块用于设置模板测试。

- Ref：参考值，和当前像素的模板值比较。
- Comp：比较方式，如Always表示总是通过。
- Pass：测试通过时的操作，如Replace表示用Ref值替换当前模板值。
- Fail：测试失败时的操作，如Keep表示保持原值不变。

**5. Blend Zero One、ZWrite Off在渲染中分别有什么作用？**

- Blend Zero One：表示不进行混合，直接用源颜色覆盖目标颜色。
- ZWrite Off：关闭深度写入，渲染时不会修改深度缓冲区，常用于透明或特殊效果。

**6. 在Unity中，如何为不同物体设置不同的Layer？Layer在渲染流程中如何被利用？**
在Unity中，可以在Inspector面板为物体分配Layer。Layer可以用于渲染剔除、物理碰撞、摄像机Culling等。在渲染流程中，可以通过Layer Mask控制哪些物体被渲染或被特殊处理。

**7. URP（Universal Render Pipeline）中的Filtering和Render Objects的作用是什么？如何通过它们实现特定Layer的剔除或特殊渲染？**
URP中的Filtering用于过滤哪些Layer会被渲染。Render Objects可以自定义渲染流程，对特定Layer的物体应用特殊的渲染Pass，实现如遮罩、特效等功能。

**8. 你在项目中是如何实现“两个窗口看到不同画面”的？涉及哪些关键技术点？**
通过为不同窗口设置不同的Layer，并利用Stencil Buffer和自定义渲染Pass，实现每个窗口只渲染属于自己Layer的内容，从而达到“两个窗口看到不同画面”的效果。

**9. 解释一下“Pass Replace”和“Fail Keep”在Stencil操作中的具体含义和应用场景。**

- Pass Replace：模板测试通过时，用参考值替换当前像素的模板值，常用于写入遮罩区域。
- Fail Keep：模板测试失败时，保持原有模板值不变，常用于保护未被遮罩的区域。

**10. 如果要在项目中实现更多复杂的窗口交互（如多个窗口嵌套、动态变化），你会如何设计Stencil Buffer的使用策略？**
可以为每个窗口分配不同的Stencil值，嵌套时通过不同的Ref和Mask组合实现层级关系。动态变化时，合理管理Stencil值的分配和回收，避免冲突，并通过多Pass渲染实现复杂的窗口交互效果。
