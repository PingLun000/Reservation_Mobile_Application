package crc645b8b8b8a34d7d258;


public class JsonRedirectWebViewClient
	extends android.webkit.WebViewClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPageFinished:(Landroid/webkit/WebView;Ljava/lang/String;)V:GetOnPageFinished_Landroid_webkit_WebView_Ljava_lang_String_Handler\n" +
			"n_onPageStarted:(Landroid/webkit/WebView;Ljava/lang/String;Landroid/graphics/Bitmap;)V:GetOnPageStarted_Landroid_webkit_WebView_Ljava_lang_String_Landroid_graphics_Bitmap_Handler\n" +
			"";
		mono.android.Runtime.register ("JudoDotNetXamarinAndroidSDK.JsonRedirectWebViewClient, JudoDotNetXamarinAndroidSDK", JsonRedirectWebViewClient.class, __md_methods);
	}


	public JsonRedirectWebViewClient ()
	{
		super ();
		if (getClass () == JsonRedirectWebViewClient.class)
			mono.android.TypeManager.Activate ("JudoDotNetXamarinAndroidSDK.JsonRedirectWebViewClient, JudoDotNetXamarinAndroidSDK", "", this, new java.lang.Object[] {  });
	}

	public JsonRedirectWebViewClient (java.lang.String p0)
	{
		super ();
		if (getClass () == JsonRedirectWebViewClient.class)
			mono.android.TypeManager.Activate ("JudoDotNetXamarinAndroidSDK.JsonRedirectWebViewClient, JudoDotNetXamarinAndroidSDK", "System.String, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onPageFinished (android.webkit.WebView p0, java.lang.String p1)
	{
		n_onPageFinished (p0, p1);
	}

	private native void n_onPageFinished (android.webkit.WebView p0, java.lang.String p1);


	public void onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2)
	{
		n_onPageStarted (p0, p1, p2);
	}

	private native void n_onPageStarted (android.webkit.WebView p0, java.lang.String p1, android.graphics.Bitmap p2);

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
