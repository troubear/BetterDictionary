# BetterDictionary
An enhanced System.Collections.Dictionary for Unity

BetterDictionaryクラスはSystem.Collections.Generic.DictionaryクラスをUnity向けに高速化したものです。  
(※.NET Core 2.0等では逆に遅くなるのでご注意ください)

## 特徴
- ILで実装したIEqualityComparer\<T\>を使用するDictionaryクラスです。
  - System.Collections.Generic.Dictionaryクラスを継承しているため、既存プロジェクトへの導入が容易です。
- .NET 3.5ランタイムにおいて、列挙型及びプリミティブ型(intやbyte等)をキーとした場合にパフォーマンスが向上します。
  - 列挙型は70%程度、プリミティブ型は10～20%程度の高速化。
  - 列挙型をキーとした場合にボックス化が発生しません。(IEqualityComparer<T>を実装した場合と同等のパフォーマンスで動作します）
- .NET 4.6ランタイムにおいても、通常のDictionaryクラスよりは高速に動作します。
  - 列挙型は30%程度、プリミティブ型は10～20%程度の高速化。
- IL2CPP(iOS)でも**たぶん**動作します。（※十分に検証できていません）

## 導入方法
1. BetterDictionary.dllをAssets/Plugins以下に配置してください。
1. さらにBetterDictionaryPatch.csを配置することで、プロジェクトソースのSystem.Collections.Generic.DictionaryをBetterDictionaryに置き換えることができます。
