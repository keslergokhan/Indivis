/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// https://ckeditor.com/docs/ckeditor4/latest/api/CKEDITOR_config.html

	config.extraPlugins = 'colorbutton,font,justify';

	// The toolbar groups arrangement, optimized for two toolbar rows.
	config.toolbarGroups = [
		{ name: 'clipboard',   groups: [ 'clipboard', 'undo' ] },
		{ name: 'editing',     groups: [ 'find', 'selection', 'spellchecker' ] },
		{ name: 'links' },
		{ name: 'insert' },
		{ name: 'forms' },
		{ name: 'tools' },
		{ name: 'document',	   groups: [ 'mode', 'document', 'doctools' ] },
		{ name: 'others' },
		'/',
		{ name: 'basicstyles', groups: [ 'basicstyles', 'cleanup' ] },
		{ name: 'paragraph',   groups: [ 'list', 'indent', 'blocks', 'align', 'bidi' ] },
		{ name: 'styles' },
		{ name: 'colors' },
		{ name: 'about' }
	];

	config.toolbar = [
		{ name: 'document', items: ['NewPage', 'Preview', 'Print', 'Save', 'Templates'] },
		{ name: 'clipboard', items: ['-', 'Undo', 'Redo'] },
		{ name: 'editing', items: ['Find', 'Replace', '-', 'SelectAll'] },
		{ name: 'styles', items: ['Styles', 'Format', 'Font', 'FontSize'] },
		{ name: 'colors', items: ['TextColor', 'BGColor'] }, // Yazý ve arka plan renklerini ayarlamak için
		{ name: 'tools', items: ['Maximize', 'ShowBlocks'] },
		{ name: 'paragraph', items: ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'] }, // Metni hizalama araçlarý
        { name: 'about', items: ['About'] },
        { name: "colorbutton", items: ["colorbutton"]},
		{ name: 'others', items: ['-'] }, // Ayýrýcý ekleme
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
