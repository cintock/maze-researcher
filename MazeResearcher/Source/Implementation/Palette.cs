﻿/*
 * Author: cintock
 * Date: 09.01.2019
 * Created by SharpDevelop.
 */
using System;
using System.Drawing;

namespace Maze.Implementation
{
	/// <summary>
	/// Статический класс для получения хорошо различимых цветов.
	/// Каждому индексу всегда соответствует один и тот же цвет.
	/// Значения индекса не ограничивается, но после исчерпания реального
	/// набора цветов они начнут повторяться.
	/// </summary>
	public static class Palette
	{
		private const uint OpaqueColor = 0xFF000000;
		
		public static Color GetColor(int index)
		{
			if (index >= colors.Length)
			{
				index = index % colors.Length;
			}
			uint argbValue = OpaqueColor | colors[index];
			return Color.FromArgb(unchecked((int)argbValue));
		}
		
		// Список хорошо различимых цветов
		static private readonly uint[] colors = 
		{
			0x000000, 0xFFFF00, 0x1CE6FF, 0xFF34FF, 0xFF4A46, 0x008941, 0x006FA6, 0xA30059,
			0xFFDBE5, 0x7A4900, 0x0000A6, 0x63FFAC, 0xB79762, 0x004D43, 0x8FB0FF, 0x997D87,
			0x5A0007, 0x809693, 0xFEFFE6, 0x1B4400, 0x4FC601, 0x3B5DFF, 0x4A3B53, 0xFF2F80,
			0x61615A, 0xBA0900, 0x6B7900, 0x00C2A0, 0xFFAA92, 0xFF90C9, 0xB903AA, 0xD16100,
			0xDDEFFF, 0x000035, 0x7B4F4B, 0xA1C299, 0x300018, 0x0AA6D8, 0x013349, 0x00846F,
			0x372101, 0xFFB500, 0xC2FFED, 0xA079BF, 0xCC0744, 0xC0B9B2, 0xC2FF99, 0x001E09,
			0x00489C, 0x6F0062, 0x0CBD66, 0xEEC3FF, 0x456D75, 0xB77B68, 0x7A87A1, 0x788D66,
			0x885578, 0xFAD09F, 0xFF8A9A, 0xD157A0, 0xBEC459, 0x456648, 0x0086ED, 0x886F4C,
			0x34362D, 0xB4A8BD, 0x00A6AA, 0x452C2C, 0x636375, 0xA3C8C9, 0xFF913F, 0x938A81,
			0x575329, 0x00FECF, 0xB05B6F, 0x8CD0FF, 0x3B9700, 0x04F757, 0xC8A1A1, 0x1E6E00,
			0x7900D7, 0xA77500, 0x6367A9, 0xA05837, 0x6B002C, 0x772600, 0xD790FF, 0x9B9700,
			0x549E79, 0xFFF69F, 0x201625, 0x72418F, 0xBC23FF, 0x99ADC0, 0x3A2465, 0x922329,
			0x5B4534, 0xFDE8DC, 0x404E55, 0x0089A3, 0xCB7E98, 0xA4E804, 0x324E72, 0x6A3A4C,
			0x83AB58, 0x001C1E, 0xD1F7CE, 0x004B28, 0xC8D0F6, 0xA3A489, 0x806C66, 0x222800,
			0xBF5650, 0xE83000, 0x66796D, 0xDA007C, 0xFF1A59, 0x8ADBB4, 0x1E0200, 0x5B4E51,
			0xC895C5, 0x320033, 0xFF6832, 0x66E1D3, 0xCFCDAC, 0xD0AC94, 0x7ED379, 0x012C58,
			0x7A7BFF, 0xD68E01, 0x353339, 0x78AFA1, 0xFEB2C6, 0x75797C, 0x837393, 0x943A4D,
			0xB5F4FF, 0xD2DCD5, 0x9556BD, 0x6A714A, 0x001325, 0x02525F, 0x0AA3F7, 0xE98176,
			0xDBD5DD, 0x5EBCD1, 0x3D4F44, 0x7E6405, 0x02684E, 0x962B75, 0x8D8546, 0x9695C5,
			0xE773CE, 0xD86A78, 0x3E89BE, 0xCA834E, 0x518A87, 0x5B113C, 0x55813B, 0xE704C4,
			0x00005F, 0xA97399, 0x4B8160, 0x59738A, 0xFF5DA7, 0xF7C9BF, 0x643127, 0x513A01,
			0x6B94AA, 0x51A058, 0xA45B02, 0x1D1702, 0xE20027, 0xE7AB63, 0x4C6001, 0x9C6966,
			0x64547B, 0x97979E, 0x006A66, 0x391406, 0xF4D749, 0x0045D2, 0x006C31, 0xDDB6D0,
			0x7C6571, 0x9FB2A4, 0x00D891, 0x15A08A, 0xBC65E9, 0xFFFFFE, 0xC6DC99, 0x203B3C,
			0x671190, 0x6B3A64, 0xF5E1FF, 0xFFA0F2, 0xCCAA35, 0x374527, 0x8BB400, 0x797868,
			0xC6005A, 0x3B000A, 0xC86240, 0x29607C, 0x402334, 0x7D5A44, 0xCCB87C, 0xB88183,
			0xAA5199, 0xB5D6C3, 0xA38469, 0x9F94F0, 0xA74571, 0xB894A6, 0x71BB8C, 0x00B433,
			0x789EC9, 0x6D80BA, 0x953F00, 0x5EFF03, 0xE4FFFC, 0x1BE177, 0xBCB1E5, 0x76912F,
			0x003109, 0x0060CD, 0xD20096, 0x895563, 0x29201D, 0x5B3213, 0xA76F42, 0x89412E,
			0x1A3A2A, 0x494B5A, 0xA88C85, 0xF4ABAA, 0xA3F3AB, 0x00C6C8, 0xEA8B66, 0x958A9F,
			0xBDC9D2, 0x9FA064, 0xBE4700, 0x658188, 0x83A485, 0x453C23, 0x47675D, 0x3A3F00,
			0x061203, 0xDFFB71, 0x868E7E, 0x98D058, 0x6C8F7D, 0xD7BFC2, 0x3C3E6E, 0xD83D66,
			0x2F5D9B, 0x6C5E46, 0xD25B88, 0x5B656C, 0x00B57F, 0x545C46, 0x866097, 0x365D25,
			0x252F99, 0x00CCFF, 0x674E60, 0xFC009C, 0x92896B, 0x1E2324, 0xDEC9B2, 0x9D4948,
			0x85ABB4, 0x342142, 0xD09685, 0xA4ACAC, 0x00FFFF, 0xAE9C86, 0x742A33, 0x0E72C5,
			0xAFD8EC, 0xC064B9, 0x91028C, 0xFEEDBF, 0xFFB789, 0x9CB8E4, 0xAFFFD1, 0x2A364C,
			0x4F4A43, 0x647095, 0x34BBFF, 0x807781, 0x920003, 0xB3A5A7, 0x018615, 0xF1FFC8,
			0x976F5C, 0xFF3BC1, 0xFF5F6B, 0x077D84, 0xF56D93, 0x5771DA, 0x4E1E2A, 0x830055,
			0x02D346, 0xBE452D, 0x00905E, 0xBE0028, 0x6E96E3, 0x007699, 0xFEC96D, 0x9C6A7D,
			0x3FA1B8, 0x893DE3, 0x79B4D6, 0x7FD4D9, 0x6751BB, 0xB28D2D, 0xE27A05, 0xDD9CB8,
			0xAABC7A, 0x980034, 0x561A02, 0x8F7F00, 0x635000, 0xCD7DAE, 0x8A5E2D, 0xFFB3E1,
			0x6B6466, 0xC6D300, 0x0100E2, 0x88EC69, 0x8FCCBE, 0x21001C, 0x511F4D, 0xE3F6E3,
			0xFF8EB1, 0x6B4F29, 0xA37F46, 0x6A5950, 0x1F2A1A, 0x04784D, 0x101835, 0xE6E0D0,
			0xFF74FE, 0x00A45F, 0x8F5DF8, 0x4B0059, 0x412F23, 0xD8939E, 0xDB9D72, 0x604143,
			0xB5BACE, 0x989EB7, 0xD2C4DB, 0xA587AF, 0x77D796, 0x7F8C94, 0xFF9B03, 0x555196,
			0x31DDAE, 0x74B671, 0x802647, 0x2A373F, 0x014A68, 0x696628, 0x4C7B6D, 0x002C27,
			0x7A4522, 0x3B5859, 0xE5D381, 0xFFF3FF, 0x679FA0, 0x261300, 0x2C5742, 0x9131AF,
			0xAF5D88, 0xC7706A, 0x61AB1F, 0x8CF2D4, 0xC5D9B8, 0x9FFFFB, 0xBF45CC, 0x493941,
			0x863B60, 0xB90076, 0x003177, 0xC582D2, 0xC1B394, 0x602B70, 0x887868, 0xBABFB0,
			0x030012, 0xD1ACFE, 0x7FDEFE, 0x4B5C71, 0xA3A097, 0xE66D53, 0x637B5D, 0x92BEA5,
			0x00F8B3, 0xBEDDFF, 0x3DB5A7, 0xDD3248, 0xB6E4DE, 0x427745, 0x598C5A, 0xB94C59,
			0x8181D5, 0x94888B, 0xFED6BD, 0x536D31, 0x6EFF92, 0xE4E8FF, 0x20E200, 0xFFD0F2,
			0x4C83A1, 0xBD7322, 0x915C4E, 0x8C4787, 0x025117, 0xA2AA45, 0x2D1B21, 0xA9DDB0,
			0xFF4F78, 0x528500, 0x009A2E, 0x17FCE4, 0x71555A, 0x525D82, 0x00195A, 0x967874,
			0x555558, 0x0B212C, 0x1E202B, 0xEFBFC4, 0x6F9755, 0x6F7586, 0x501D1D, 0x372D00,
			0x741D16, 0x5EB393, 0xB5B400, 0xDD4A38, 0x363DFF, 0xAD6552, 0x6635AF, 0x836BBA,
			0x98AA7F, 0x464836, 0x322C3E, 0x7CB9BA, 0x5B6965, 0x707D3D, 0x7A001D, 0x6E4636,
			0x443A38, 0xAE81FF, 0x489079, 0x897334, 0x009087, 0xDA713C, 0x361618, 0xFF6F01,
			0x006679, 0x370E77, 0x4B3A83, 0xC9E2E6, 0xC44170, 0xFF4526, 0x73BE54, 0xC4DF72,
			0xADFF60, 0x00447D, 0xDCCEC9, 0xBD9479, 0x656E5B, 0xEC5200, 0xFF6EC2, 0x7A617E,
			0xDDAEA2, 0x77837F, 0xA53327, 0x608EFF, 0xB599D7, 0xA50149, 0x4E0025, 0xC9B1A9,
			0x03919A, 0x1B2A25, 0xE500F1, 0x982E0B, 0xB67180, 0xE05859, 0x006039, 0x578F9B,
			0x305230, 0xCE934C, 0xB3C2BE, 0xC0BAC0, 0xB506D3, 0x170C10, 0x4C534F, 0x224451,
			0x3E4141, 0x78726D, 0xB6602B, 0x200441, 0xDDB588, 0x497200, 0xC5AAB6, 0x033C61,
			0x71B2F5, 0xA9E088, 0x4979B0, 0xA2C3DF, 0x784149, 0x2D2B17, 0x3E0E2F, 0x57344C,
			0x0091BE, 0xE451D1, 0x4B4B6A, 0x5C011A, 0x7C8060, 0xFF9491, 0x4C325D, 0x005C8B,
			0xE5FDA4, 0x68D1B6, 0x032641, 0x140023, 0x8683A9, 0xCFFF00, 0xA72C3E, 0x34475A,
			0xB1BB9A, 0xB4A04F, 0x8D918E, 0xA168A6, 0x813D3A, 0x425218, 0xDA8386, 0x776133,
			0x563930, 0x8498AE, 0x90C1D3, 0xB5666B, 0x9B585E, 0x856465, 0xAD7C90, 0xE2BC00,
			0xE3AAE0, 0xB2C2FE, 0xFD0039, 0x009B75, 0xFFF46D, 0xE87EAC, 0xDFE3E6, 0x848590,
			0xAA9297, 0x83A193, 0x577977, 0x3E7158, 0xC64289, 0xEA0072, 0xC4A8CB, 0x55C899,
			0xE78FCF, 0x004547, 0xF6E2E3, 0x966716, 0x378FDB, 0x435E6A, 0xDA0004, 0x1B000F,
			0x5B9C8F, 0x6E2B52, 0x011115, 0xE3E8C4, 0xAE3B85, 0xEA1CA9, 0xFF9E6B, 0x457D8B,
			0x92678B, 0x00CDBB, 0x9CCC04, 0x002E38, 0x96C57F, 0xCFF6B4, 0x492818, 0x766E52,
			0x20370E, 0xE3D19F, 0x2E3C30, 0xB2EACE, 0xF3BDA4, 0xA24E3D, 0x976FD9, 0x8C9FA8,
			0x7C2B73, 0x4E5F37, 0x5D5462, 0x90956F, 0x6AA776, 0xDBCBF6, 0xDA71FF, 0x987C95,
			0x52323C, 0xBB3C42, 0x584D39, 0x4FC15F, 0xA2B9C1, 0x79DB21, 0x1D5958, 0xBD744E,
			0x160B00, 0x20221A, 0x6B8295, 0x00E0E4, 0x102401, 0x1B782A, 0xDAA9B5, 0xB0415D,
			0x859253, 0x97A094, 0x06E3C4, 0x47688C, 0x7C6755, 0x075C00, 0x7560D5, 0x7D9F00,
			0xC36D96, 0x4D913E, 0x5F4276, 0xFCE4C8, 0x303052, 0x4F381B, 0xE5A532, 0x706690,
			0xAA9A92, 0x237363, 0x73013E, 0xFF9079, 0xA79A74, 0x029BDB, 0xFF0169, 0xC7D2E7,
			0xCA8869, 0x80FFCD, 0xBB1F69, 0x90B0AB, 0x7D74A9, 0xFCC7DB, 0x99375B, 0x00AB4D,
			0xABAED1, 0xBE9D91, 0xE6E5A7, 0x332C22, 0xDD587B, 0xF5FFF7, 0x5D3033, 0x6D3800,
			0xFF0020, 0xB57BB3, 0xD7FFE6, 0xC535A9, 0x260009, 0x6A8781, 0xA8ABB4, 0xD45262,
			0x794B61, 0x4621B2, 0x8DA4DB, 0xC7C890, 0x6FE9AD, 0xA243A7, 0xB2B081, 0x181B00,
			0x286154, 0x4CA43B, 0x6A9573, 0xA8441D, 0x5C727B, 0x738671, 0xD0CFCB, 0x897B77,
			0x1F3F22, 0x4145A7, 0xDA9894, 0xA1757A, 0x63243C, 0xADAAFF, 0x00CDE2, 0xDDBC62,
			0x698EB1, 0x208462, 0x00B7E0, 0x614A44, 0x9BBB57, 0x7A5C54, 0x857A50, 0x766B7E,
			0x014833, 0xFF8347, 0x7A8EBA, 0x274740, 0x946444, 0xEBD8E6, 0x646241, 0x373917,
			0x6AD450, 0x81817B, 0xD499E3, 0x979440, 0x011A12, 0x526554, 0xB5885C, 0xA499A5,
			0x03AD89, 0xB3008B, 0xE3C4B5, 0x96531F, 0x867175, 0x74569E, 0x617D9F, 0xE70452,
			0x067EAF, 0xA697B6, 0xB787A8, 0x9CFF93, 0x311D19, 0x3A9459, 0x6E746E, 0xB0C5AE,
			0x84EDF7, 0xED3488, 0x754C78, 0x384644, 0xC7847B, 0x00B6C5, 0x7FA670, 0xC1AF9E,
			0x2A7FFF, 0x72A58C, 0xFFC07F, 0x9DEBDD, 0xD97C8E, 0x7E7C93, 0x62E674, 0xB5639E,
			0xFFA861, 0xC2A580, 0x8D9C83, 0xB70546, 0x372B2E, 0x0098FF, 0x985975, 0x20204C,
			0xFF6C60, 0x445083, 0x8502AA, 0x72361F, 0x9676A3, 0x484449, 0xCED6C2, 0x3B164A,
			0xCCA763, 0x2C7F77, 0x02227B, 0xA37E6F, 0xCDE6DC, 0xCDFFFB, 0xBE811A, 0xF77183,
			0xEDE6E2, 0xCDC6B4, 0xFFE09E, 0x3A7271, 0xFF7B59, 0x4E4E01, 0x4AC684, 0x8BC891,
			0xBC8A96, 0xCF6353, 0xDCDE5C, 0x5EAADD, 0xF6A0AD, 0xE269AA, 0xA3DAE4, 0x436E83,
			0x002E17, 0xECFBFF, 0xA1C2B6, 0x50003F, 0x71695B, 0x67C4BB, 0x536EFF, 0x5D5A48,
			0x890039, 0x969381, 0x371521, 0x5E4665, 0xAA62C3, 0x8D6F81, 0x2C6135, 0x410601,
			0x564620, 0xE69034, 0x6DA6BD, 0xE58E56, 0xE3A68B, 0x48B176, 0xD27D67, 0xB5B268,
			0x7F8427, 0xFF84E6, 0x435740, 0xEAE408, 0xF4F5FF, 0x325800, 0x4B6BA5, 0xADCEFF,
			0x9B8ACC, 0x885138, 0x5875C1, 0x7E7311, 0xFEA5CA, 0x9F8B5B, 0xA55B54, 0x89006A,
			0xAF756F, 0x2A2000, 0x7499A1, 0xFFB550, 0x00011E, 0xD1511C, 0x688151, 0xBC908A,
			0x78C8EB, 0x8502FF, 0x483D30, 0xC42221, 0x5EA7FF, 0x785715, 0x0CEA91, 0xFFFAED,
			0xB3AF9D, 0x3E3D52, 0x5A9BC2, 0x9C2F90, 0x8D5700, 0xADD79C, 0x00768B, 0x337D00,
			0xC59700, 0x3156DC, 0x944575, 0xECFFDC, 0xD24CB2, 0x97703C, 0x4C257F, 0x9E0366,
			0x88FFEC, 0xB56481, 0x396D2B, 0x56735F, 0x988376, 0x9BB195, 0xA9795C, 0xE4C5D3,
			0x9F4F67, 0x1E2B39, 0x664327, 0xAFCE78, 0x322EDF, 0x86B487, 0xC23000, 0xABE86B,
			0x96656D, 0x250E35, 0xA60019, 0x0080CF, 0xCAEFFF, 0x323F61, 0xA449DC, 0x6A9D3B,
			0xFF5AE4, 0x636A01, 0xD16CDA, 0x736060, 0xFFBAAD, 0xD369B4, 0xFFDED6, 0x6C6D74,
			0x927D5E, 0x845D70, 0x5B62C1, 0x2F4A36, 0xE45F35, 0xFF3B53, 0xAC84DD, 0x762988,
			0x70EC98, 0x408543, 0x2C3533, 0x2E182D, 0x323925, 0x19181B, 0x2F2E2C, 0x023C32,
			0x9B9EE2, 0x58AFAD, 0x5C424D, 0x7AC5A6, 0x685D75, 0xB9BCBD, 0x834357, 0x1A7B42,
			0x2E57AA, 0xE55199, 0x316E47, 0xCD00C5, 0x6A004D, 0x7FBBEC, 0xF35691, 0xD7C54A,
			0x62ACB7, 0xCBA1BC, 0xA28A9A, 0x6C3F3B, 0xFFE47D, 0xDCBAE3, 0x5F816D, 0x3A404A,
			0x7DBF32, 0xE6ECDC, 0x852C19, 0x285366, 0xB8CB9C, 0x0E0D00, 0x4B5D56, 0x6B543F,
			0xE27172, 0x0568EC, 0x2EB500, 0xD21656, 0xEFAFFF, 0x682021, 0x2D2011, 0xDA4CFF,
			0x70968E, 0xFF7B7D, 0x4A1930, 0xE8C282, 0xE7DBBC, 0xA68486, 0x1F263C, 0x36574E,
			0x52CE79, 0xADAAA9, 0x8A9F45, 0x6542D2, 0x00FB8C, 0x5D697B, 0xCCD27F, 0x94A5A1,
			0x790229, 0xE383E6, 0x7EA4C1, 0x4E4452, 0x4B2C00, 0x620B70, 0x314C1E, 0x874AA6,
			0xE30091, 0x66460A, 0xEB9A8B, 0xEAC3A3, 0x98EAB3, 0xAB9180, 0xB8552F, 0x1A2B2F,
			0x94DDC5, 0x9D8C76, 0x9C8333, 0x94A9C9, 0x392935, 0x8C675E, 0xCCE93A, 0x917100,
			0x01400B, 0x449896, 0x1CA370, 0xE08DA7, 0x8B4A4E, 0x667776, 0x4692AD, 0x67BDA8,
			0x69255C, 0xD3BFFF, 0x4A5132, 0x7E9285, 0x77733C, 0xE7A0CC, 0x51A288, 0x2C656A,
			0x4D5C5E, 0xC9403A, 0xDDD7F3, 0x005844, 0xB4A200, 0x488F69, 0x858182, 0xD4E9B9,
			0x3D7397, 0xCAE8CE, 0xD60034, 0xAA6746, 0x9E5585, 0xBA6200		
		};
	}
}
