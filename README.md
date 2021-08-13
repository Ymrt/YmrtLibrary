# YmrtLibrary
一个WPF小控件库，目前只有一个控件
在页面中写入以下代码：
```
<Grid>
        <Slider Maximum="100" Minimum="0" Width="600" x:Name="_Slider"/>
        <local:ProgressTrailing Width="600" Height="7" SymbolRadius="7.5" Background="#FFDBDDE8" SymbolBorderThickness="0"
                                ValueColor="#FF74E440" SymbolBorderColor="Transparent"  SymbolColor="#FF0BE80B" SymbolBorderRadius="20"
                                Value="{Binding Value ,ElementName=_Slider}"/>
</Grid>
```
![avatar](https://github.com/Ymrt/YmrtLibrary/blob/master/image01.png)  
改变它的值时会产生拖尾效果  
![avatar](https://github.com/Ymrt/YmrtLibrary/blob/master/animation01.gif)

