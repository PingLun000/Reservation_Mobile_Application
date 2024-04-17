package crc64eb0f21405e49869d;


public class JudoEntryRenderer
	extends crc64720bb2db43a66fe9.ViewRenderer_2
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("JudoXamarin.Droid.Renderers.JudoEntryRenderer, JudoDotNetXamarinAndroidSDK", JudoEntryRenderer.class, __md_methods);
	}


	public JudoEntryRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == JudoEntryRenderer.class)
			mono.android.TypeManager.Activate ("JudoXamarin.Droid.Renderers.JudoEntryRenderer, JudoDotNetXamarinAndroidSDK", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public JudoEntryRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == JudoEntryRenderer.class)
			mono.android.TypeManager.Activate ("JudoXamarin.Droid.Renderers.JudoEntryRenderer, JudoDotNetXamarinAndroidSDK", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public JudoEntryRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == JudoEntryRenderer.class)
			mono.android.TypeManager.Activate ("JudoXamarin.Droid.Renderers.JudoEntryRenderer, JudoDotNetXamarinAndroidSDK", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
