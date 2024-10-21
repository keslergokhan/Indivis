/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// https://ckeditor.com/docs/ckeditor4/latest/api/CKEDITOR_config.html

	config.extraPlugins = 'colorbutton,font,justify,autogrow';
	config.autoGrow_minHeight = 100; // Minimum yükseklik
	config.autoGrow_maxHeight = 600; // Maksimum yükseklik
	config.autoGrow_bottomSpace = 50; // Alt boþluk miktarý

	
	config.toolbar = [
		{ name: 'editing', items: ['find', 'selection'] },
		{ name: 'basicstyles', items: ['Bold', 'Italic'] },
		{ name: 'document', items: ['NewPage', 'Preview', 'Print', 'Save', 'Templates'] },
		{ name: 'clipboard', items: ['-', 'Undo', 'Redo'] },
		{ name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll'] },
		{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
		{ name: 'colors', items: ['TextColor', 'BGColor'] }, // Yazý ve arka plan renklerini ayarlamak için
		{ name: 'tools', items: ['Maximize', 'ShowBlocks'] },
		{ name: 'paragraph', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] }, // Metni hizalama araçlarý
		{ name: "colorbutton", items: ["colorbutton"] },
		{ name: "Localization", items: ["LocalizationSave","LocalizationClose"]}

	];

	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
	config.removeButtons = 'Underline,Subscript,Superscript';

	// Set the most common block elements.
    config.format_tags = 'p;h1;h2;h3;pre';

    // Yazý boyutlandýrma seçenekleri
    config.fontSize_sizes = '8/8pt;10/10pt;12/12pt;14/14pt;16/16pt;18/18pt;20/20pt;24/24pt;28/28pt;32/32pt;40/40pt;48/48pt';

	// Simplify the dialog windows.
	config.removeDialogTabs = 'image:advanced;link:advanced';

};
