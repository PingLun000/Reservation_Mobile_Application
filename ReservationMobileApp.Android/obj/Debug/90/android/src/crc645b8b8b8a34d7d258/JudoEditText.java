package crc645b8b8b8a34d7d258;


public class JudoEditText
	extends android.support.design.widget.TextInputEditText
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTextContextMenuItem:(I)Z:GetOnTextContextMenuItem_IHandler\n" +
			"";
		mono.android.Runtime.register ("JudoDotNetXamarinAndroidSDK.JudoEditText, JudoDotNetXamarinAndroidSDK", JudoEditText.class, __md_methods);
	}


	public JudoEditText (android.content.Context p0)
	{
		super (p0);
		if (getClass () == JudoEditText.class)
			mono.android.TypeManager.Activate ("JudoDotNetXamarinAndroidSDK.JudoEditText, JudoDotNetXamarinAndroidSDK", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public JudoEditText (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == JudoEditText.class)
			mono.android.TypeManager.Activate ("JudoDotNetXamarinAndroidSDK.JudoEditText, JudoDotNetXamarinAndroidSDK", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public JudoEditText (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == JudoEditText.class)
			mono.android.TypeManager.Activate ("JudoDotNetXamarinAndroidSDK.JudoEditText, JudoDotNetXamarinAndroidSDK", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean onTextContextMenuItem (int p0)
	{
		return n_onTextContextMenuItem (p0);
	}

	private native boolean n_onTextContextMenuItem (int p0);

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
