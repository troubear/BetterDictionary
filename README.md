BetterDictionary for Unity
===
本ライブラリが提供するDictionary/HashSetクラスは、System.Collections.Generic名前空間の同名クラスをUnity向けに高速化※したものです。  

    ※.NET Core 2.0等の環境で使用した場合、逆にパフォーマンスが低下する場合があります。

特徴
---
- 一部をILで実装したIEqualityComparer\<T\>を使用するDictionary/HashSetクラスです。
  - System.Collections.Generic名前空間の同名クラスを継承しているため、既存プロジェクトへの導入が比較的容易です。
- .NET 3.5ランタイムにおいて、列挙型・プリミティブ型(intやbyte等)・string型をキーとした場合にパフォーマンスが向上します。
  - 列挙型は\~70%程度、プリミティブ型は\~20%程度、string型は\~15%程度の高速化。
  - **列挙型をキーとした場合にボックス化が発生しません。**(IEqualityComparer<T>を実装した場合と同等のパフォーマンスで動作します）
- .NET 4.6ランタイムにおいても、通常のDictionary/HashSetクラスよりは高速に動作します。
  - 列挙型は\~30%程度、プリミティブ型は\~20%程度、string型は\~20%程度の高速化。
- IL2CPP(iOS/Android)に対応しています。  
  - ※但し、IL2CPPが生成するC++コードのコンパイルエラーを強引に回避しているため、将来的にコンパイルが通らなくなる可能性があります。

導入方法
---
1. [リリースページ](https://github.com/komatus/BetterDictionary/releases)から最新版の.unitypackageをダウンロード＆インストールします。
    - リポジトリのAssets/Plugins以下を直接自身のプロジェクトにコピーしても問題ありません。
1. 既存コードを以下のように変更します。  
    
    ```csharp
    // Before:
    Dictionary<MyEnum, string> _dict = new Dictionary<MyEnum, string>();
    HashSet<string> _strings         = new HashSet<string>();

    // After:
    Dictionary<MyEnum, string> _dict = new Better.Dictionary<MyEnum, string>();
    HashSet<string> _strings         = new Better.HashSet<string>();
    ```

1. または、`PlayerSettings`の`Scripting Define Symbols`に`BETTER_PATCH`を追加し、プロジェクトソース内で使用されているSystem.Collections.Generic名前空間のDictionary/HashSetクラスを本ライブラリのクラスで一括置換※します。
    - ※`BETTER_PATCH`シンボルの追加によって、本ライブラリのDictionary/HashSetクラスがグローバル名前空間で定義されます。

StringKey (ハッシュ計算済み文字列キー)
---
Better.StringKeyを使用することで、Dictionary/HashSetへのアクセスを高速化することができます。

~~~csharp
using Better;

// Typical extension method of the Dictionary class
public static void AddOrUpdate<TKey, TValue>(
  this Dictionary<TKey, TValue> dict, TKey key, TValue value)
{
  if (dict.ContainsKey(key))
  {
    dict[key] = value;
  }
  else
  {
    dict.Add(key, value);
  }
}

Dictionary<string, int> dict1;
Dictionary<StringKey, int> dict2;

dict1.AddOrUpdate("hogehoge", 1234);

// Depending on the length of the string,
// several percent to tens of percent faster than the raw string key.
// 文字列の長さによって、stringキーより数パーセント～数十パーセント速くなります。
dict2.AddOrUpdate("hogehoge", 1234);

// Attention!!
// However, in the case of a single operation it will slow down about 30%.
// ※但し、単一オペレーションでは約30%程度遅くなります。
dict2["hogehoge"] = 5678;

// Therefore, it is strongly recommended to prepare StringKey in advance.
// 従って、StringKeyを事前に用意しておくことを強く推奨します。
static StringKey HogeHoge = "hogehoge";
dict2[HogeHoge] = 5678; // Faster than dict1["hogehoge"]
~~~

TODO
---
- 詳細なパフォーマンス計測＆グラフ化
- Translate the README into English.

License
---
This library is under the MIT License.

Some code is borrowed from [Microsoft/referencesource](https://github.com/Microsoft/referencesource).
