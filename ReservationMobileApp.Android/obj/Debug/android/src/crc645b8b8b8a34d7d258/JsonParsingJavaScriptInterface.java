package crc645b8b8b8a34d7d258;


public class JsonParsingJavaScriptInterface
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_ParseJsonFromHtml:(Ljava/lang/String;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("JudoDotNetXamarinAndroidSDK.JsonParsingJavaScriptInterface, JudoDotNetXamarinAndroidSDK", JsonParsingJavaScriptInterface.class, __md_methods);
	}


	public JsonParsingJavaScriptInterface ()
	{
		super ();
		if (getClass () == JsonParsingJavaScriptInterface.class)
			mono.android.TypeManager.Activate ("JudoDotNetXamarinAndroidSDK.JsonParsingJavaScriptInterface, JudoDotNetXamarinAndroidSDK", "", this, new java.lang.Object[] {  });
	}

	@android.webkit.JavascriptInterface

	public void parseJsonFromHtml (java.lang.String p0)
	{
		n_ParseJsonFromHtml (p0);
	}

	private native void n_ParseJsonFromHtml (java.lang.String p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
